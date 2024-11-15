using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EcoVolt.Models;
using EcoVolt.Repositories;
using EcoVolt.Repositories.Interfaces;

namespace EcoVolt.Controllers
{
    public class GsConsumoEnergiaController : Controller
    {
        private readonly IGsConsumoEnergiaRepository _consumoEnergiaRepository;

        public GsConsumoEnergiaController(IGsConsumoEnergiaRepository consumoEnergiaRepository)
        {
            _consumoEnergiaRepository = consumoEnergiaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var consumosEnergia = await _consumoEnergiaRepository.GetAllAsync();
            return View(consumosEnergia);
        }

        public async Task<IActionResult> Details(int id)
        {
            var consumoEnergia = await _consumoEnergiaRepository.GetByIdAsync(id);
            if (consumoEnergia == null)
            {
                return NotFound();
            }
            return View(consumoEnergia);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GsConsumoEnergia consumoEnergia)
        {
            if (ModelState.IsValid)
            {
                await _consumoEnergiaRepository.AddAsync(consumoEnergia);
                return RedirectToAction(nameof(Index));
            }
            return View(consumoEnergia);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var consumoEnergia = await _consumoEnergiaRepository.GetByIdAsync(id);
            if (consumoEnergia == null)
            {
                return NotFound();
            }
            return View(consumoEnergia);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GsConsumoEnergia consumoEnergia)
        {
            if (id != consumoEnergia.IdConsumo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _consumoEnergiaRepository.UpdateAsync(consumoEnergia);
                return RedirectToAction(nameof(Index));
            }
            return View(consumoEnergia);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var consumoEnergia = await _consumoEnergiaRepository.GetByIdAsync(id);
            if (consumoEnergia == null)
            {
                return NotFound();
            }
            return View(consumoEnergia);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _consumoEnergiaRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
