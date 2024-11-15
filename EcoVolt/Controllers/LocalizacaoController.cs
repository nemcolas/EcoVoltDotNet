using EcoVolt.Models;
using EcoVolt.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcoVolt.Controllers
{
    public class LocalizacaoController : Controller
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;

        public LocalizacaoController(ILocalizacaoRepository localizacaoRepository)
        {
            _localizacaoRepository = localizacaoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var localizacoes = await _localizacaoRepository.GetAllAsync();
            return View(localizacoes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var localizacao = await _localizacaoRepository.GetByIdAsync(id.Value);
            if (localizacao == null) return NotFound();

            return View(localizacao);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Latitude, Longitude, EnderecoCompleto, CodBairro")] Localizacao localizacao)
        {
            if (ModelState.IsValid)
            {
                await _localizacaoRepository.AddAsync(localizacao);
                return RedirectToAction(nameof(Index));
            }
            return View(localizacao);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var localizacao = await _localizacaoRepository.GetByIdAsync(id.Value);
            if (localizacao == null) return NotFound();

            return View(localizacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Latitude, Longitude, EnderecoCompleto, CodBairro")] Localizacao localizacao)
        {
            if (id != localizacao.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _localizacaoRepository.UpdateAsync(localizacao);
                return RedirectToAction(nameof(Index));
            }
            return View(localizacao);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var localizacao = await _localizacaoRepository.GetByIdAsync(id.Value);
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
