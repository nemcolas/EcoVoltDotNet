using Microsoft.AspNetCore.Mvc;
using EcoVolt.Data;
using EcoVolt.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Controllers
{
    public class TipoFonteController : Controller
    {
        private readonly AppDbContext _context;

        public GsTipoFonteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GsTipoFonte
        public async Task<IActionResult> Index()
        {
            return View(await _context.GsTipoFonte.ToListAsync());
        }

        // GET: GsTipoFonte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tipoFonte = await _context.GsTipoFonte.FirstOrDefaultAsync(m => m.Id == id);
            if (tipoFonte == null) return NotFound();

            return View(tipoFonte);
        }

        // GET: GsTipoFonte/Create
        public IActionResult Create() => View();

        // POST: GsTipoFonte/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] GsTipoFonte tipoFonte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoFonte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoFonte);
        }

        // GET: GsTipoFonte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tipoFonte = await _context.GsTipoFonte.FindAsync(id);
            if (tipoFonte == null) return NotFound();

            return View(tipoFonte);
        }

        // POST: GsTipoFonte/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] GsTipoFonte tipoFonte)
        {
            if (id != tipoFonte.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoFonte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoFonteExists(tipoFonte.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoFonte);
        }

        // GET: GsTipoFonte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tipoFonte = await _context.GsTipoFonte.FirstOrDefaultAsync(m => m.Id == id);
            if (tipoFonte == null) return NotFound();

            return View(tipoFonte);
        }

        // POST: GsTipoFonte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoFonte = await _context.GsTipoFonte.FindAsync(id);
            _context.GsTipoFonte.Remove(tipoFonte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoFonteExists(int id) => _context.GsTipoFonte.Any(e => e.Id == id);
    }
}
