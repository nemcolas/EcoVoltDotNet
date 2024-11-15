using Microsoft.AspNetCore.Mvc;
using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;

namespace EcoVolt.Controllers
{
    public class GsFonteEnergiaController : Controller
    {
        private readonly IGsFonteEnergiaRepository _fonteEnergiaRepository;

        public GsFonteEnergiaController(IGsFonteEnergiaRepository fonteEnergiaRepository)
        {
            _fonteEnergiaRepository = fonteEnergiaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var fontesEnergia = await _fonteEnergiaRepository.GetAllAsync();
            return View(fontesEnergia);
        }

        public async Task<IActionResult> Details(int id)
        {
            var fonteEnergia = await _fonteEnergiaRepository.GetByIdAsync(id);
            if (fonteEnergia == null)
            {
                return NotFound();
            }
            return View(fonteEnergia);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GsFonteEnergia fonteEnergia)
        {
            if (ModelState.IsValid)
            {
                await _fonteEnergiaRepository.AddAsync(fonteEnergia);
                return RedirectToAction(nameof(Index));
            }
            return View(fonteEnergia);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var fonteEnergia = await _fonteEnergiaRepository.GetByIdAsync(id);
            if (fonteEnergia == null)
            {
                return NotFound();
            }
            return View(fonteEnergia);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GsFonteEnergia fonteEnergia)
        {
            if (id != fonteEnergia.IdFonte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _fonteEnergiaRepository.UpdateAsync(fonteEnergia);
                return RedirectToAction(nameof(Index));
            }
            return View(fonteEnergia);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var fonteEnergia = await _fonteEnergiaRepository.GetByIdAsync(id);
            if (fonteEnergia == null)
            {
                return NotFound();
            }
            return View(fonteEnergia);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _fonteEnergiaRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
