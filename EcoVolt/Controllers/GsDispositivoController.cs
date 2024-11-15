using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EcoVolt.Models;
using EcoVolt.Repositories;
using EcoVolt.Repositories.Interfaces;

namespace EcoVolt.Controllers
{
    public class GsDispositivoController : Controller
    {
        private readonly IGsDispositivoRepository _dispositivoRepository;

        public GsDispositivoController(IGsDispositivoRepository dispositivoRepository)
        {
            _dispositivoRepository = dispositivoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var dispositivos = await _dispositivoRepository.GetAllAsync();
            return View(dispositivos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var dispositivo = await _dispositivoRepository.GetByIdAsync(id);
            if (dispositivo == null)
            {
                return NotFound();
            }
            return View(dispositivo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GsDispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                await _dispositivoRepository.AddAsync(dispositivo);
                return RedirectToAction(nameof(Index));
            }
            return View(dispositivo);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dispositivo = await _dispositivoRepository.GetByIdAsync(id);
            if (dispositivo == null)
            {
                return NotFound();
            }
            return View(dispositivo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GsDispositivo dispositivo)
        {
            if (id != dispositivo.IdDispositivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _dispositivoRepository.UpdateAsync(dispositivo);
                return RedirectToAction(nameof(Index));
            }
            return View(dispositivo);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dispositivo = await _dispositivoRepository.GetByIdAsync(id);
            if (dispositivo == null)
            {
                return NotFound();
            }
            return View(dispositivo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _dispositivoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
