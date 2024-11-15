using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EcoVolt.Models;
using EcoVolt.Repositories;
using EcoVolt.Repositories.Interfaces;

namespace EcoVolt.Controllers
{
    public class GsTipoConsumidorController : Controller
    {
        private readonly IGsTipoConsumidorRepository _tipoConsumidorRepository;

        public GsTipoConsumidorController(IGsTipoConsumidorRepository tipoConsumidorRepository)
        {
            _tipoConsumidorRepository = tipoConsumidorRepository;
        }

        public async Task<IActionResult> Index()
        {
            var tiposConsumidor = await _tipoConsumidorRepository.GetAllAsync();
            return View(tiposConsumidor);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tipoConsumidor = await _tipoConsumidorRepository.GetByIdAsync(id);
            if (tipoConsumidor == null)
            {
                return NotFound();
            }
            return View(tipoConsumidor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GsTipoConsumidor tipoConsumidor)
        {
            if (ModelState.IsValid)
            {
                await _tipoConsumidorRepository.AddAsync(tipoConsumidor);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoConsumidor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tipoConsumidor = await _tipoConsumidorRepository.GetByIdAsync(id);
            if (tipoConsumidor == null)
            {
                return NotFound();
            }
            return View(tipoConsumidor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GsTipoConsumidor tipoConsumidor)
        {
            if (id != tipoConsumidor.IdTipoConsumidor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _tipoConsumidorRepository.UpdateAsync(tipoConsumidor);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoConsumidor);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tipoConsumidor = await _tipoConsumidorRepository.GetByIdAsync(id);
            if (tipoConsumidor == null)
            {
                return NotFound();
            }
            return View(tipoConsumidor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _tipoConsumidorRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
