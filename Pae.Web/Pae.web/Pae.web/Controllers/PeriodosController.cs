using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pae.web.Data;
using Pae.web.Data.Entities;

namespace Pae.web.Controllers
{
    public class PeriodosController : Controller
    {
        private readonly DataContext _context;

        public PeriodosController(DataContext context)
        {
            _context = context;
        }

        // GET: Periodos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Periodos.ToListAsync());
        }

        // GET: Periodos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodos = await _context.Periodos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periodos == null)
            {
                return NotFound();
            }

            return View(periodos);
        }

        // GET: Periodos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Periodos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MonthDelivery")] Periodos periodos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(periodos);
        }

        // GET: Periodos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodos = await _context.Periodos.FindAsync(id);
            if (periodos == null)
            {
                return NotFound();
            }
            return View(periodos);
        }

        // POST: Periodos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MonthDelivery")] Periodos periodos)
        {
            if (id != periodos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodosExists(periodos.Id))
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
            return View(periodos);
        }

        // GET: Periodos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodos = await _context.Periodos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periodos == null)
            {
                return NotFound();
            }

            return View(periodos);
        }

        // POST: Periodos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var periodos = await _context.Periodos.FindAsync(id);
            _context.Periodos.Remove(periodos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodosExists(int id)
        {
            return _context.Periodos.Any(e => e.Id == id);
        }
    }
}
