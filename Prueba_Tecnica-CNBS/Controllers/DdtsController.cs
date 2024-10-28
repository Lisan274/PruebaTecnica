using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Prueba_Tecnica_CNBS.Models;

namespace Prueba_Tecnica_CNBS.Controllers
{
    public class DdtsController : Controller
    {
        private readonly DeclaracionesDbContext _context;
        private readonly ApiService _apiService;

        public DdtsController(DeclaracionesDbContext context, ApiService apiService)
        {
            _context = context;
            _apiService = apiService;
        }

        public async Task<IActionResult> LoadData(string fecha)
        {
            try
            {
                // Obtener datos desde el servicio
                var xmlData = await _apiService.GetDeclarationsDataAsync(fecha);

                // Extraer el valor de datosComprimidos
                var datosComprimidos = xmlData.Root?.Element("datosComprimidos")?.Value;
                if (string.IsNullOrEmpty(datosComprimidos))
                {
                    return BadRequest("No se encontraron datos comprimidos.");
                }

                // Descomprimir datosComprimidos
                var jsonData = await ApiService.DecompressAsync(datosComprimidos);

                // Convertir JSON a objeto .NET (estructura de las declaraciones)
                var declaraciones = JsonConvert.DeserializeObject<List<Ddt>>(jsonData) ?? new List<Ddt>();

                if (declaraciones.Count > 0)
                {
                    _context.Ddts.AddRange(declaraciones);
                    await _context.SaveChangesAsync();
                    return Ok("Datos cargados y almacenados con éxito.");
                }
                else
                {
                    return BadRequest("No se encontraron declaraciones para guardar.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al cargar datos: {ex.Message}");
            }
        }



        // GET: Ddts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ddt = await _context.Ddts
                .Include(d => d.Arts) // Cargar los artículos relacionados
                .FirstOrDefaultAsync(m => m.Iddt == id);

            if (ddt == null)
            {
                return NotFound();
            }

            return View(ddt);
        }

        // GET: Ddts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ddts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddt,Cddtver,Iddtext,Iext,Cddteta,Dddtoficia,Dddtrectifa,Cddtcirvis,Qddttaxchg,Ista,Cddtbur,Cddtburdst,Cddtdep,Cddtentrep,Cddtage,Cddtagr,Lddtagr,Nddtimmioe,Lddtnomioe,Cddtpayori,Cddtpaidst,Lddtnomfod,Cddtincote,Cddtdevfob,Cddtdevfle,Cddtdevass,Cddttransp,Cddtmdetrn,Cddtpaytrn,Nddtart,Nddtdelai,Dddtbae,Dddtsalida,Dddtcancel,Dddtechean,Cddtobs")] Ddt ddt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ddt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ddt);
        }

        // GET: Ddts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ddt = await _context.Ddts.FindAsync(id);
            if (ddt == null)
            {
                return NotFound();
            }
            return View(ddt);
        }

        // POST: Ddts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Iddt,Cddtver,Iddtext,Iext,Cddteta,Dddtoficia,Dddtrectifa,Cddtcirvis,Qddttaxchg,Ista,Cddtbur,Cddtburdst,Cddtdep,Cddtentrep,Cddtage,Cddtagr,Lddtagr,Nddtimmioe,Lddtnomioe,Cddtpayori,Cddtpaidst,Lddtnomfod,Cddtincote,Cddtdevfob,Cddtdevfle,Cddtdevass,Cddttransp,Cddtmdetrn,Cddtpaytrn,Nddtart,Nddtdelai,Dddtbae,Dddtsalida,Dddtcancel,Dddtechean,Cddtobs")] Ddt ddt)
        {
            if (id != ddt.Iddt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ddt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DdtExists(ddt.Iddt))
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
            return View(ddt);
        }

        // GET: Ddts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ddt = await _context.Ddts
                .FirstOrDefaultAsync(m => m.Iddt == id);
            if (ddt == null)
            {
                return NotFound();
            }

            return View(ddt);
        }

        // POST: Ddts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ddt = await _context.Ddts.FindAsync(id);
            if (ddt != null)
            {
                _context.Ddts.Remove(ddt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DdtExists(string id)
        {
            return _context.Ddts.Any(e => e.Iddt == id);
        }

        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var declaraciones = from d in _context.Ddts
                                select d;

            if (!string.IsNullOrEmpty(searchString))
            {
                declaraciones = declaraciones.Where(d => d.Nddtimmioe.Contains(searchString));
            }

            return View(await declaraciones.ToListAsync());
        }

    }
}
