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
    public class InstitucionsController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public InstitucionsController(
            DataContext context,
            IConverterHelper converterHelper)
        {
            _context = context;
          _converterHelper = converterHelper;
        }

        // GET: Institucions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Institucions.ToListAsync());
        }

        // GET: Institucions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucion = await _context.Institucions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institucion == null)
            {
                return NotFound();
            }

            return View(institucion);
        }

        // GET: Institucions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Institucions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameIntitucion")] Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institucion);
        }

        // GET: Institucions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucion = await _context.Institucions.FindAsync(id);
            if (institucion == null)
            {
                return NotFound();
            }
            return View(institucion);
        }

        // POST: Institucions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameIntitucion")] Institucion institucion)
        {
            if (id != institucion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institucion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitucionExists(institucion.Id))
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
            return View(institucion);
        }

        // GET: Institucions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucion = await _context.Institucions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institucion == null)
            {
                return NotFound();
            }

            return View(institucion);
        }

        // POST: Institucions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institucion = await _context.Institucions.FindAsync(id);
            _context.Institucions.Remove(institucion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitucionExists(int id)
        {
            return _context.Institucions.Any(e => e.Id == id);
        }
        public async Task<IActionResult> AddSede(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sede = await _context.Institucions.FindAsync(id);
            if (sede == null)
            {
                return NotFound();
            }
            var model = new AddSedeViewModel
            {
                InstitucionId=sede.Id
             
               
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddSede(AddSedeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelfull = new AddSedeViewModel
                {
                    InstitucionId = model.Id,
                    NameSedes = model.NameSedes
                    
                };
                var sede = await _converterHelper.ToSedeAsync(modelfull, true);
                _context.Sedes.Add(sede);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.InstitucionId}");
            }
           
            return View(model);
        }
    }
}
