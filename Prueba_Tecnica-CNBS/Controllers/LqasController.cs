using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica_CNBS.Models;

namespace Prueba_Tecnica_CNBS.Controllers
{
    public class LqasController : Controller
    {
        private readonly DeclaracionesDbContext _context;

        public LqasController(DeclaracionesDbContext context)
        {
            _context = context;
        }

        // GET: Lqas
        public async Task<IActionResult> Index()
        {
            var declaracionesDbContext = _context.Lqas.Include(l => l.Art).Include(l => l.IliqNavigation);
            return View(await declaracionesDbContext.ToListAsync());
        }

        // GET: Lqas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lqa = await _context.Lqas
                .Include(l => l.Art)
                .Include(l => l.IliqNavigation)
                .FirstOrDefaultAsync(m => m.Iliq == id);
            if (lqa == null)
            {
                return NotFound();
            }

            return View(lqa);
        }

        // GET: Lqas/Create
        public IActionResult Create()
        {
            ViewData["Iddt"] = new SelectList(_context.Arts, "Iddt", "Iddt");
            ViewData["Iliq"] = new SelectList(_context.Liqs, "Iliq", "Iliq");
            return View();
        }

        // POST: Lqas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iliq,Iddt,Nart,Clqatax,Clqatyp,Mlqabas,Qlqacoefic,Mlqa")] Lqa lqa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lqa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Iddt"] = new SelectList(_context.Arts, "Iddt", "Iddt", lqa.Iddt);
            ViewData["Iliq"] = new SelectList(_context.Liqs, "Iliq", "Iliq", lqa.Iliq);
            return View(lqa);
        }

        // GET: Lqas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lqa = await _context.Lqas.FindAsync(id);
            if (lqa == null)
            {
                return NotFound();
            }
            ViewData["Iddt"] = new SelectList(_context.Arts, "Iddt", "Iddt", lqa.Iddt);
            ViewData["Iliq"] = new SelectList(_context.Liqs, "Iliq", "Iliq", lqa.Iliq);
            return View(lqa);
        }

        // POST: Lqas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Iliq,Iddt,Nart,Clqatax,Clqatyp,Mlqabas,Qlqacoefic,Mlqa")] Lqa lqa)
        {
            if (id != lqa.Iliq)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lqa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LqaExists(lqa.Iliq))
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
            ViewData["Iddt"] = new SelectList(_context.Arts, "Iddt", "Iddt", lqa.Iddt);
            ViewData["Iliq"] = new SelectList(_context.Liqs, "Iliq", "Iliq", lqa.Iliq);
            return View(lqa);
        }

        // GET: Lqas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lqa = await _context.Lqas
                .Include(l => l.Art)
                .Include(l => l.IliqNavigation)
                .FirstOrDefaultAsync(m => m.Iliq == id);
            if (lqa == null)
            {
                return NotFound();
            }

            return View(lqa);
        }

        // POST: Lqas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lqa = await _context.Lqas.FindAsync(id);
            if (lqa != null)
            {
                _context.Lqas.Remove(lqa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LqaExists(string id)
        {
            return _context.Lqas.Any(e => e.Iliq == id);
        }
    }
}
