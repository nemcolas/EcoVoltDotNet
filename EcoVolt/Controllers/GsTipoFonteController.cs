using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EcoVolt.Models;
using EcoVolt.Repositories;
using EcoVolt.Repositories.Interfaces;

namespace EcoVolt.Controllers
{
    public class GsTipoFonteController : Controller
    {
        private readonly IGsTipoFonteRepository _tipoFonteRepository;

        public GsTipoFonteController(IGsTipoFonteRepository tipoFonteRepository)
        {
            _tipoFonteRepository = tipoFonteRepository;
        }

        public async Task<IActionResult> Index()
        {
            var tiposFonte = await _tipoFonteRepository.GetAllAsync();
            return View(tiposFonte);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tipoFonte = await _tipoFonteRepository.GetByIdAsync(id);
            if (tipoFonte == null)
            {
                return NotFound();
            }
            return View(tipoFonte);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GsTipoFonte tipoFonte)
        {
            if (ModelState.IsValid)
            {
                await _tipoFonteRepository.AddAsync(tipoFonte);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoFonte);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tipoFonte = await _tipoFonteRepository.GetByIdAsync(id);
            if (tipoFonte == null)
            {
                return NotFound();
            }
            return View(tipoFonte);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GsTipoFonte tipoFonte)
        {
            if (id != tipoFonte.IdTipoFonte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _tipoFonteRepository.UpdateAsync(tipoFonte);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoFonte);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tipoFonte = await _tipoFonteRepository.GetByIdAsync(id);
            if (tipoFonte == null)
            {
                return NotFound();
            }
            return View(tipoFonte);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _tipoFonteRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
