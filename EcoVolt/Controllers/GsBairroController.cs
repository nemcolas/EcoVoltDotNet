using Microsoft.AspNetCore.Mvc;
using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;

namespace EcoVolt.Controllers
{
    [Route("gsbairro")]
    public class GsBairroController : Controller
    {
        private readonly IGsBairroRepository _bairroRepository;

        public GsBairroController(IGsBairroRepository bairroRepository)
        {
            _bairroRepository = bairroRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var bairros = await _bairroRepository.GetAllAsync();
            return View(bairros);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var bairro = await _bairroRepository.GetByIdAsync(id);
            if (bairro == null) return NotFound();
            return View(bairro);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GsBairro bairro)
        {
            if (ModelState.IsValid)
            {
                await _bairroRepository.AddAsync(bairro);
                return RedirectToAction(nameof(Index));
            }
            return View(bairro);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var bairro = await _bairroRepository.GetByIdAsync(id);
            if (bairro == null) return NotFound();
            return View(bairro);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GsBairro bairro)
        {
            if (id != bairro.CodBairro) return NotFound();
            if (ModelState.IsValid)
            {
                await _bairroRepository.UpdateAsync(bairro);
                return RedirectToAction(nameof(Index));
            }
            return View(bairro);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bairro = await _bairroRepository.GetByIdAsync(id);
            if (bairro == null) return NotFound();
            return View(bairro);
        }

        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bairroRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
