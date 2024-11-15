using Microsoft.AspNetCore.Mvc;
using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;

namespace EcoVolt.Controllers
{
    public class GsGeracaoEnergiaController : Controller
    {
        private readonly IGsGeracaoEnergiaRepository _geracaoEnergiaRepository;

        public GsGeracaoEnergiaController(IGsGeracaoEnergiaRepository geracaoEnergiaRepository)
        {
            _geracaoEnergiaRepository = geracaoEnergiaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var geracoesEnergia = await _geracaoEnergiaRepository.GetAllAsync();
            return View(geracoesEnergia);
        }

        public async Task<IActionResult> Details(int id)
        {
            var geracaoEnergia = await _geracaoEnergiaRepository.GetByIdAsync(id);
            if (geracaoEnergia == null)
            {
                return NotFound();
            }
            return View(geracaoEnergia);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GsGeracaoEnergia geracaoEnergia)
        {
            if (ModelState.IsValid)
            {
                await _geracaoEnergiaRepository.AddAsync(geracaoEnergia);
                return RedirectToAction(nameof(Index));
            }
            return View(geracaoEnergia);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var geracaoEnergia = await _geracaoEnergiaRepository.GetByIdAsync(id);
            if (geracaoEnergia == null)
            {
                return NotFound();
            }
            return View(geracaoEnergia);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GsGeracaoEnergia geracaoEnergia)
        {
            if (id != geracaoEnergia.IdGeracao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _geracaoEnergiaRepository.UpdateAsync(geracaoEnergia);
                return RedirectToAction(nameof(Index));
            }
            return View(geracaoEnergia);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var geracaoEnergia = await _geracaoEnergiaRepository.GetByIdAsync(id);
            if (geracaoEnergia == null)
            {
                return NotFound();
            }
            return View(geracaoEnergia);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _geracaoEnergiaRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
