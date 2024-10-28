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
    public class LiqsController : Controller
    {
        private readonly DeclaracionesDbContext _context;

        public LiqsController(DeclaracionesDbContext context)
        {
            _context = context;
        }

        // GET: Liqs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Liqs.ToListAsync());
        }

        // GET: Liqs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liq = await _context.Liqs
                .FirstOrDefaultAsync(m => m.Iliq == id);
            if (liq == null)
            {
                return NotFound();
            }

            return View(liq);
        }

        // GET: Liqs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Liqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iliq,Cliqdop,Cliqeta,Mliq,Mliqgar,Dlippay,Clipnomope")] Liq liq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(liq);
        }

        // GET: Liqs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liq = await _context.Liqs.FindAsync(id);
            if (liq == null)
            {
                return NotFound();
            }
            return View(liq);
        }

        // POST: Liqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Iliq,Cliqdop,Cliqeta,Mliq,Mliqgar,Dlippay,Clipnomope")] Liq liq)
        {
            if (id != liq.Iliq)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiqExists(liq.Iliq))
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
            return View(liq);
        }

        // GET: Liqs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liq = await _context.Liqs
                .FirstOrDefaultAsync(m => m.Iliq == id);
            if (liq == null)
            {
                return NotFound();
            }

            return View(liq);
        }

        // POST: Liqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var liq = await _context.Liqs.FindAsync(id);
            if (liq != null)
            {
                _context.Liqs.Remove(liq);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiqExists(string id)
        {
            return _context.Liqs.Any(e => e.Iliq == id);
        }
    }
}
