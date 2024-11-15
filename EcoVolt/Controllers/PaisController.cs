using EcoVolt.Models;
using EcoVolt.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EcoVolt.Repositories.Interfaces;

namespace EcoVolt.Controllers
{
    public class PaisController : Controller
    {
        private readonly IGsPaisRepository _paisRepository;

        public PaisController(IGsPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        // GET: Pais
        public async Task<IActionResult> Index()
        {
            var paises = await _paisRepository.GetAllAsync();
            return View(paises);
        }

        // GET: Pais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var pais = await _paisRepository.GetByIdAsync(id.Value);
            if (pais == null) return NotFound();

            return View(pais);
        }

        // GET: Pais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome")] GsPais pais)
        {
            if (ModelState.IsValid)
            {
                await _paisRepository.AddAsync(pais);
                return RedirectToAction(nameof(Index));
            }
            return View(pais);
        }

        // GET: Pais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var pais = await _paisRepository.GetByIdAsync(id.Value);
            if (pais == null) return NotFound();

            return View(pais);
        }

        // POST: Pais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodPais, Nome")] GsPais pais)
        {
            if (id != pais.CodPais) return NotFound();

            if (ModelState.IsValid)
            {
                await _paisRepository.UpdateAsync(pais);
                return RedirectToAction(nameof(Index));
            }
            return View(pais);
        }

        // GET: Pais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var pais = await _paisRepository.GetByIdAsync(id.Value);
            if (pais == null) return NotFound();

            return View(pais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _paisRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
