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
    public class EstudentsController : Controller
    {
        private readonly DataContext _context;

        public EstudentsController(DataContext context)
        {
            _context = context;
        }

        // GET: Estudents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudents.ToListAsync());
        }

        // GET: Estudents/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Estudents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
    }
}
