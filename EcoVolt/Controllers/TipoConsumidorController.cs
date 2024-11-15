using Microsoft.AspNetCore.Mvc;
using EcoVolt.Data;
using EcoVolt.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Controllers
{
    public class TipoConsumidorController : Controller
    {
        private readonly AppDbContext _context;

        public TipoConsumidorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoConsumidor
        public async Task<IActionResult> Index()
        {
            return View(await _context.GsTipoConsumidor.ToListAsync());
        }

        // GET: TipoConsumidor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConsumidor = await _context.GsTipoConsumidor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoConsumidor == null)
            {
                return NotFound();
            }

            return View(tipoConsumidor);
        }

        // GET: TipoConsumidor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoConsumidor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] GsTipoConsumidor tipoConsumidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoConsumidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoConsumidor);
        }

        // GET: TipoConsumidor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConsumidor = await _context.GsTipoConsumidor.FindAsync(id);
            if (tipoConsumidor == null)
            {
                return NotFound();
            }
            return View(tipoConsumidor);
        }

        // POST: TipoConsumidor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] GsTipoConsumidor tipoConsumidor)
        {
            if (id != tipoConsumidor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoConsumidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoConsumidorExists(tipoConsumidor.Id))
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
            return View(tipoConsumidor);
        }

        // GET: TipoConsumidor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConsumidor = await _context.GsTipoConsumidor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoConsumidor == null)
            {
                return NotFound();
            }

            return View(tipoConsumidor);
        }

        // POST: TipoConsumidor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoConsumidor = await _context.GsTipoConsumidor.FindAsync(id);
            _context.GsTipoConsumidor.Remove(tipoConsumidor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoConsumidorExists(int id)
        {
            return _context.GsTipoConsumidor.Any(e => e.Id == id);
        }
    }
}
