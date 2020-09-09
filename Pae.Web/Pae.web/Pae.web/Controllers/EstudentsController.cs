﻿using System;
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

        public EstudentsController(DataContext context,
            ICombosHelpers combosHelpers,
            IConverterHelper converterHelper)
        {
            _context = context;
            _combosHelpers = combosHelpers;
            _converterHelper = converterHelper;
        }

        // GET: Estudents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudents.ToListAsync());
        }

        // GET: Estudents/Details/5 DetailsActa
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudents = await _context.Estudents
                .Include(a => a.Site)
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
            //var model = new EstudentViewModel
            //{
            //    DateRegistro = DateTime.Today,

            //    Areas = _combosHelpers.GetComboAreas(),
            //    Eps = _combosHelpers.GetComboEps(),
            //    Pension = _combosHelpers.GetComboPension(),
            //    CajaCompensacion = _combosHelpers.GetComboCajaCompensacion(),
            //    PositionEmplooyed = _combosHelpers.GetComboPositionEmploye(),
            //    //Roles = _combosHelpers.GetComboRoles()
            //};
            //model.Areas = _combosHelpers.GetComboAreas();
            //model.Eps = _combosHelpers.GetComboEps();
            //model.Pension = _combosHelpers.GetComboPension();
            //model.CajaCompensacion = _combosHelpers.GetComboCajaCompensacion();
            //model.PositionEmplooyed = _combosHelpers.GetComboPositionEmploye();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Document,FullName")] Estudents estudents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudents);
        }

        // GET: Estudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudents = await _context.Estudents.FindAsync(id);
            if (estudents == null)
            {
                return NotFound();
            }
            return View(estudents);
        }

        // POST: Estudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Document,FullName")] Estudents estudents)
        {
            if (id != estudents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudentsExists(estudents.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estudents);
        }

        // GET: Estudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudents = await _context.Estudents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudents == null)
            {
                return NotFound();
            }

            return View(estudents);
        }

        // POST: Estudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudents = await _context.Estudents.FindAsync(id);
            _context.Estudents.Remove(estudents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
                var modelfull = new DetailsActaViewModel
                {
                    StudentId = model.StudentId,
                    DocAcudiente = model.DocAcudiente,
                    FullNameAcudiente=model.FullNameAcudiente,
                    ActaId=model.ActaId,
                    
                    ImageActaUrl = model.ImageActaUrl,
                    ImageAcudienteUrl = model.ImageAcudienteUrl,
                    ImageDeliveryUrl = model.ImageDeliveryUrl,
                    ImageStudentUrl = model.ImageStudentUrl,
                    SiteDelivery = model.SiteDelivery,
                    TelMovil = model.TelMovil,


                };
                var examen = await _converterHelper.ToDetailDataActaAsync(modelfull, true);
                _context.DetailsDeliveries.Add(examen);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.StudentId}");
            }
          
            return View(model);
            }
        }
    }

