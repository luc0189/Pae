using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pae.web.Data;
using Pae.web.Data.Entities;
using Pae.web.Helpers;
using Pae.web.Models;

namespace Pae.web.Controllers
{
    public class EstudentsController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelpers _combosHelpers;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public EstudentsController(DataContext context,
            ICombosHelpers combosHelpers,
            IConverterHelper converterHelper,
            IImageHelper imageHelper)
        {
            _context = context;
            _combosHelpers = combosHelpers;
            _converterHelper = converterHelper;
           _imageHelper = imageHelper;
        }
        public async Task<IActionResult> SearchDoc(int? usr)
        {
            if (usr == null)
            {
                return NotFound();
            }
            try
            {
                var estudents = await _context.Estudents
               .Include(s => s.Sedes)
               .FirstOrDefaultAsync(m => m.Document == Convert.ToString(usr));
                if (estudents == null)
                {
                    return NotFound();
                }
                return RedirectToAction($"Details/{estudents.Id}");
            }
            catch (Exception e)
            {

                return RedirectToAction(nameof(Index));
            }

        }
        public async Task<IActionResult> SearchName(string name)
        {
            if (name == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var estudents = await _context.Estudents
               .Include(s => s.Sedes)
               .FirstOrDefaultAsync(m => m.FullName == Convert.ToString(name));
                if (estudents == null)
                {
                    return NotFound();
                }
                return RedirectToAction($"Details/{estudents.Id}");
            }
            catch (Exception e)
            {

                return RedirectToAction(nameof(Index));
            }
        }
        // GET: Estudents
        public IActionResult Index()
        {
            return View();
        }

        // GET: Estudents/Details/5 DetailsActa
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudents = await _context.Estudents
                .Include(a => a.Sedes)
                .Include(a => a.DeliveryActas)
                .ThenInclude(d => d.DetailsDeliveries)
                .Include(a => a.DeliveryActas)
                .ThenInclude(p => p.Periodos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudents == null)
            {
                return NotFound();
            }

            return View(estudents);
        }

        // GET: Estudents/Create
        public IActionResult Create()
        {
            var student = new EstudentViewModel
            {
                Sedes = _combosHelpers.GetComboSedes(),
                
            };

            student.Sedes = _combosHelpers.GetComboSedes();

            return View(student);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = new Estudents
                {
                    NOrden=model.NOrden,
                    Document= model.Document,
                    DeliveryActas = new List<DeliveryActa>(),
                   FullName=model.FullName,
                   Mesa=model.Mesa,
                   Sedes= await _context.Sedes.FindAsync(model.SedeId)

                };
                try
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e )
                {
                    ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException}";
                    return View(model);
                }
               
            }
            return View(model);
        }

        // GET: Estudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudents = await _context.Estudents
                .Include(s=>s.Sedes)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (estudents == null)
            {
                return NotFound();
            }
            var model = new EstudentViewModel
            {
                Document=estudents.Document,
                NOrden=estudents.NOrden,
                FullName=estudents.FullName,
                Id=estudents.Id,
                Mesa=estudents.Mesa,
                SedeId=estudents.Sedes.Id,
                Sedes= _combosHelpers.GetComboSedes()
            };
            return View(model);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EstudentViewModel vista)
        {
            if (ModelState.IsValid)
            {
                var student = await _context.Estudents
                     .Include(s => s.Sedes)
                     .FirstOrDefaultAsync(o => o.Id == vista.Id);
                if (student != null)
                {
                    student.Document = vista.Document;
                    student.Sedes = await _context.Sedes.FindAsync(vista.SedeId);
                    student.FullName = vista.FullName;
                    student.Id = vista.Id;
                    student.Mesa = vista.Mesa;
                    student.NOrden = vista.NOrden;

                    try
                    {
                        _context.Estudents.Update(student);
                        await _context.SaveChangesAsync();
                        return RedirectToAction($"Details/{student.Id}");
                    }
                    catch (Exception e)
                    {
                        ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException}";
                        return View(vista);
                    }

                    
                }
            }

            return View(vista);
        }

        // GET: Estudents/Delete/5
        public async Task<IActionResult> DeleteActa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var deliveryActa = await _context.DeliveryActas
                    .Include(e=>e.Estudents)    
                    .FirstOrDefaultAsync(d=>d.Id==id);
                if (deliveryActa == null)
                {
                    return NotFound();
                }
                _context.DeliveryActas.Remove(deliveryActa);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{deliveryActa.Estudents.Id}");

            }
            catch (Exception e)
            {
                ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException}";
                return NotFound();


            }

          
        }

       

        private bool EstudentsExists(int id)
        {
            return _context.Estudents.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AddDeliveryActa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employe = await _context.Estudents.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            var model = new DeliveryActaViewModel
            {

                EstudentId = employe.Id,

                Periodos = _combosHelpers.GetComboPeriodoTypes(),
                Usucrea = User.Identity.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddDeliveryActa(DeliveryActaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelfull = new DeliveryActaViewModel
                {
                    EstudentId = model.EstudentId,
                    Usucrea = User.Identity.Name,
                    PeriodoId = model.PeriodoId,
                    Periodos = model.Periodos,

                };
                var examen = await _converterHelper.ToCreditAsync(modelfull, true);
                _context.DeliveryActas.Add(examen);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.EstudentId}");
            }
            model.Periodos = _combosHelpers.GetComboPeriodoTypes();
            return View(model);
        }

        public async Task<IActionResult> DetailsActa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var acta = await _context.DeliveryActas
                .Include(e => e.Estudents)
                .Include(p => p.Periodos)
                .Include(a => a.DetailsDeliveries)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (acta == null)
            {
                return NotFound();
            }
            var model = new DetailsActaViewModel
            {

                StudentId = acta.Estudents.Id,

            };


            return View(acta);
        }
        public async Task<IActionResult> DetailsDataActa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var acta = await _context.DeliveryActas
                .Include(e => e.DetailsDeliveries)
                .Include(p => p.Periodos)
                .Include(s => s.Estudents)

                .FirstOrDefaultAsync(a => a.Id == id);
            if (acta == null)
            {
                return NotFound();
            }
            var model = new DetailsActaViewModel
            {
                ActaId = acta.Id,
                StudentId = acta.Estudents.Id

            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DetailsDataActa(DetailsActaViewModel model)
        {
            if (ModelState.IsValid)
            {
                string ruta = "";
                string ruta2 = "";
                var frente = string.Empty;
                var reverso = string.Empty;
                var delivery = string.Empty;

                if (model.ImageDocfrente != null)
                {
                    ruta = "wwwroot\\images\\Actas";
                    ruta2 = "~/images/Actas/";
                    frente = await _imageHelper.UploadImageAsync(model.ImageDocfrente,ruta,ruta2);
                }
                if (model.ImageDocReverso != null)
                {
                    
                    ruta = "wwwroot\\images\\Actas";
                    ruta2 = "~/images/Actas/";
                    reverso = await _imageHelper.UploadImageAsync(model.ImageDocReverso,ruta,ruta2);
                }
                if (model.ImageDelivery != null)
                {
                    ruta = "wwwroot\\images\\Deliveries";
                    ruta2 = "~/images/Deliveries/";
                    delivery = await _imageHelper.UploadImageAsync(model.ImageDelivery,ruta,ruta2);
                }

               
                var modelfull = new DetailsActaViewModel
                {
                    StudentId = model.StudentId,
                    DocAcudiente = model.DocAcudiente,
                    FullNameAcudiente=model.FullNameAcudiente,
                    ActaId=model.ActaId,
                    Imagedocl=frente,
                    Imagedoc2=reverso,
                    
                    SiteDelivery = model.SiteDelivery,
                    TelMovil = model.TelMovil,


                };
                var examen = await _converterHelper.ToDetailDataActaAsync(modelfull, true);
                _context.DetailsDeliveries.Add(examen);
                await _context.SaveChangesAsync();
                return RedirectToAction($"DetailsActa/{model.ActaId}");
            }
          
            return View(model);
            }


        public async Task<IActionResult> EditDelivery(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deliveryActa = await _context.DeliveryActas
                .Include(s => s.Estudents)
                .Include(p=>p.Periodos)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (deliveryActa == null)
            {
                return NotFound();
            }
           
            return View(_converterHelper.ToDeliveryActaViewModel(deliveryActa));
        }
        [HttpPost]
        public async Task<IActionResult> EditDelivery(DeliveryActaViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                try
                {
                    var deliveyActa = await _converterHelper.ToDeliveryActaAsync(model, false);
                    _context.DeliveryActas.Update(deliveyActa);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{model.EstudentId}");
                }
                catch (Exception e)
                {

                    throw;
                }
                
            }
            return View(model);


        }
    }
    }

