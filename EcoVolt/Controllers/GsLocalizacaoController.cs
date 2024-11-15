using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcoVolt.Models;
using EcoVolt.Repositories;
using EcoVolt.Repositories.Interfaces;

namespace EcoVolt.Controllers
{
    public class GsLocalizacaoController : Controller
    {
        private readonly IGsLocalizacaoRepository _localizacaoRepository;

        public GsLocalizacaoController(IGsLocalizacaoRepository localizacaoRepository)
        {
            _localizacaoRepository = localizacaoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var localizacoes = await _localizacaoRepository.GetAllAsync();
            return View(localizacoes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var localizacao = await _localizacaoRepository.GetByIdAsync(id);
            if (localizacao == null) return NotFound();
            return View(localizacao);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GsLocalizacao localizacao)
        {
            if (ModelState.IsValid)
            {
                await _localizacaoRepository.AddAsync(localizacao);
                return RedirectToAction(nameof(Index));
            }
            return View(localizacao);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var localizacao = await _localizacaoRepository.GetByIdAsync(id);
            if (localizacao == null) return NotFound();
            return View(localizacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GsLocalizacao localizacao)
        {
            if (id != localizacao.IdLocalizacao) return NotFound();
            if (ModelState.IsValid)
            {
                await _localizacaoRepository.UpdateAsync(localizacao);
                return RedirectToAction(nameof(Index));
            }
            return View(localizacao);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var localizacao = await _localizacaoRepository.GetByIdAsync(id);
            if (localizacao == null) return NotFound();
            return View(localizacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _localizacaoRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
