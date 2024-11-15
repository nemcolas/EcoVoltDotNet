using Microsoft.AspNetCore.Mvc;
using EcoVolt.Data;
using EcoVolt.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Controllers
{
    public class GsTipoDispositivoController : Controller
    {
        private readonly AppDbContext _context;

        public GsTipoDispositivoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GsTipoDispositivo
        public async Task<IActionResult> Index()
        {
            return View(await _context.GsTipoDispositivo.ToListAsync());
        }

        // GET: GsTipoDispositivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tipoDispositivo = await _context.GsTipoDispositivo.FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDispositivo == null) return NotFound();

            return View(tipoDispositivo);
        }

        // GET: GsTipoDispositivo/Create
        public IActionResult Create() => View();

        // POST: GsTipoDispositivo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] GsTipoDispositivo tipoDispositivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDispositivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDispositivo);
        }

        // GET: GsTipoDispositivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tipoDispositivo = await _context.GsTipoDispositivo.FindAsync(id);
            if (tipoDispositivo == null) return NotFound();

            return View(tipoDispositivo);
        }

        // POST: GsTipoDispositivo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] GsTipoDispositivo tipoDispositivo)
        {
            if (id != tipoDispositivo.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDispositivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDispositivoExists(tipoDispositivo.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDispositivo);
        }

        // GET: GsTipoDispositivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tipoDispositivo = await _context.GsTipoDispositivo.FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDispositivo == null) return NotFound();

            return View(tipoDispositivo);
        }

        // POST: GsTipoDispositivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDispositivo = await _context.GsTipoDispositivo.FindAsync(id);
            _context.GsTipoDispositivo.Remove(tipoDispositivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDispositivoExists(int id) => _context.GsTipoDispositivo.Any(e => e.Id == id);
    }
}
