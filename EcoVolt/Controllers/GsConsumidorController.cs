using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EcoVolt.Models;
using EcoVolt.Repositories;
using EcoVolt.Repositories.Interfaces;

namespace EcoVolt.Controllers
{
    public class GsConsumidorController : Controller
    {
        private readonly IGsConsumidorRepository _consumidorRepository;

        public GsConsumidorController(IGsConsumidorRepository consumidorRepository)
        {
            _consumidorRepository = consumidorRepository;
        }

        public async Task<IActionResult> Index()
        {
            var consumidores = await _consumidorRepository.GetAllAsync();
            return View(consumidores);
        }

        public async Task<IActionResult> Details(int id)
        {
            var consumidor = await _consumidorRepository.GetByIdAsync(id);
            if (consumidor == null)
            {
                return NotFound();
            }
            return View(consumidor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GsConsumidor consumidor)
        {
            if (ModelState.IsValid)
            {
                await _consumidorRepository.AddAsync(consumidor);
                return RedirectToAction(nameof(Index));
            }
            return View(consumidor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var consumidor = await _consumidorRepository.GetByIdAsync(id);
            if (consumidor == null)
            {
                return NotFound();
            }
            return View(consumidor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GsConsumidor consumidor)
        {
            if (id != consumidor.IdConsumidor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _consumidorRepository.UpdateAsync(consumidor);
                return RedirectToAction(nameof(Index));
            }
            return View(consumidor);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var consumidor = await _consumidorRepository.GetByIdAsync(id);
            if (consumidor == null)
            {
                return NotFound();
            }
            return View(consumidor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _consumidorRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
