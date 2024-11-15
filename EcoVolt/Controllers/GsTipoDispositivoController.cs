using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EcoVolt.Models;
using EcoVolt.Repositories;
using EcoVolt.Repositories.Interfaces;

namespace EcoVolt.Controllers
{
    public class GsTipoDispositivoController : Controller
    {
        private readonly IGsTipoDispositivoRepository _tipoDispositivoRepository;

        public GsTipoDispositivoController(IGsTipoDispositivoRepository tipoDispositivoRepository)
        {
            _tipoDispositivoRepository = tipoDispositivoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var tiposDispositivo = await _tipoDispositivoRepository.GetAllAsync();
            return View(tiposDispositivo);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tipoDispositivo = await _tipoDispositivoRepository.GetByIdAsync(id);
            if (tipoDispositivo == null)
            {
                return NotFound();
            }
            return View(tipoDispositivo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GsTipoDispositivo tipoDispositivo)
        {
            if (ModelState.IsValid)
            {
                await _tipoDispositivoRepository.AddAsync(tipoDispositivo);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDispositivo);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tipoDispositivo = await _tipoDispositivoRepository.GetByIdAsync(id);
            if (tipoDispositivo == null)
            {
                return NotFound();
            }
            return View(tipoDispositivo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GsTipoDispositivo tipoDispositivo)
        {
            if (id != tipoDispositivo.IdTipoDispositivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _tipoDispositivoRepository.UpdateAsync(tipoDispositivo);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDispositivo);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tipoDispositivo = await _tipoDispositivoRepository.GetByIdAsync(id);
            if (tipoDispositivo == null)
            {
                return NotFound();
            }
            return View(tipoDispositivo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _tipoDispositivoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
