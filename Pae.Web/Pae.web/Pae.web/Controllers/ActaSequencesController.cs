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
    public class ActaSequencesController : Controller
    {
        private readonly DataContext _context;

        public ActaSequencesController(DataContext context)
        {
            _context = context;
        }

        // GET: ActaSequences
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActaSequences.ToListAsync());
        }

        // GET: ActaSequences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actaSequence = await _context.ActaSequences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actaSequence == null)
            {
                return NotFound();
            }

            return View(actaSequence);
        }

        // GET: ActaSequences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActaSequences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Prefix,Sequence")] ActaSequence actaSequence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actaSequence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actaSequence);
        }

        // GET: ActaSequences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actaSequence = await _context.ActaSequences.FindAsync(id);
            if (actaSequence == null)
            {
                return NotFound();
            }
            return View(actaSequence);
        }

        // POST: ActaSequences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Prefix,Sequence")] ActaSequence actaSequence)
        {
            if (id != actaSequence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actaSequence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActaSequenceExists(actaSequence.Id))
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
            return View(actaSequence);
        }

        // GET: ActaSequences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actaSequence = await _context.ActaSequences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actaSequence == null)
            {
                return NotFound();
            }

            return View(actaSequence);
        }

        // POST: ActaSequences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actaSequence = await _context.ActaSequences.FindAsync(id);
            _context.ActaSequences.Remove(actaSequence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActaSequenceExists(int id)
        {
            return _context.ActaSequences.Any(e => e.Id == id);
        }
    }
}
