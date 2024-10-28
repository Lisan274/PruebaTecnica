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
    public class ArtsController : Controller
    {
        private readonly DeclaracionesDbContext _context;

        public ArtsController(DeclaracionesDbContext context)
        {
            _context = context;
        }

        // GET: Arts
        public async Task<IActionResult> Index()
        {
            var declaracionesDbContext = _context.Arts.Include(a => a.IddtNavigation);
            return View(await declaracionesDbContext.ToListAsync());
        }

        // GET: Arts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art = await _context.Arts
                .Include(a => a.IddtNavigation)
                .FirstOrDefaultAsync(m => m.Iddt == id);
            if (art == null)
            {
                return NotFound();
            }

            return View(art);
        }

        // GET: Arts/Create
        public IActionResult Create()
        {
            ViewData["Iddt"] = new SelectList(_context.Ddts, "Iddt", "Iddt");
            return View();
        }

        // POST: Arts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddt,Nart,Carttyp,Codbenef,Cartetamrc,Iespnce,Cartdesc,Cartpayori,Cartpayacq,Cartpayprc,Iddtapu,Nartapu,Qartbul,Martunitar,Cartuntdcl,Qartuntdcl,Cartuntest,Qartuntest,Qartkgrbrt,Qartkgrnet,Martfob,Martfobdol,Martfle,Martass,Martemma,Martfrai,Martajuinc,Martajuded,Martbasimp")] Art art)
        {
            if (ModelState.IsValid)
            {
                _context.Add(art);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Iddt"] = new SelectList(_context.Ddts, "Iddt", "Iddt", art.Iddt);
            return View(art);
        }

        // GET: Arts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art = await _context.Arts.FindAsync(id);
            if (art == null)
            {
                return NotFound();
            }
            ViewData["Iddt"] = new SelectList(_context.Ddts, "Iddt", "Iddt", art.Iddt);
            return View(art);
        }

        // POST: Arts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Iddt,Nart,Carttyp,Codbenef,Cartetamrc,Iespnce,Cartdesc,Cartpayori,Cartpayacq,Cartpayprc,Iddtapu,Nartapu,Qartbul,Martunitar,Cartuntdcl,Qartuntdcl,Cartuntest,Qartuntest,Qartkgrbrt,Qartkgrnet,Martfob,Martfobdol,Martfle,Martass,Martemma,Martfrai,Martajuinc,Martajuded,Martbasimp")] Art art)
        {
            if (id != art.Iddt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(art);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtExists(art.Iddt))
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
            ViewData["Iddt"] = new SelectList(_context.Ddts, "Iddt", "Iddt", art.Iddt);
            return View(art);
        }

        // GET: Arts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var art = await _context.Arts
                .Include(a => a.IddtNavigation)
                .FirstOrDefaultAsync(m => m.Iddt == id);
            if (art == null)
            {
                return NotFound();
            }

            return View(art);
        }

        // POST: Arts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var art = await _context.Arts.FindAsync(id);
            if (art != null)
            {
                _context.Arts.Remove(art);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtExists(string id)
        {
            return _context.Arts.Any(e => e.Iddt == id);
        }
    }
}
