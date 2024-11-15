using EcoVolt.Models;
using EcoVolt.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcoVolt.Controllers
{
    public class FonteEnergiaController : Controller
    {
        private readonly IFonteEnergiaRepository _fonteEnergiaRepository;

        public FonteEnergiaController(IFonteEnergiaRepository fonteEnergiaRepository)
        {
            _fonteEnergiaRepository = fonteEnergiaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var fontes = await _fonteEnergiaRepository.GetAllAsync();
            return View(fontes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var fonte = await _fonteEnergiaRepository.GetByIdAsync(id.Value);
            if (fonte == null) return NotFound();

            return View(fonte);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GeracaoEnergiaKwh, CapacidadeBateriaKwh, IdTipoFonte, IdLocalizacao")] FonteEnergia fonte)
        {
            if (ModelState.IsValid)
            {
                await _fonteEnergiaRepository.AddAsync(fonte);
                return RedirectToAction(nameof(Index));
            }
            return View(fonte);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var fonte = await _fonteEnergiaRepository.GetByIdAsync(id.Value);
            if (fonte == null) return NotFound();

            return View(fonte);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, GeracaoEnergiaKwh, CapacidadeBateriaKwh, IdTipoFonte, IdLocalizacao")] FonteEnergia fonte)
        {
            if (id != fonte.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _fonteEnergiaRepository.UpdateAsync(fonte);
                return RedirectToAction(nameof(Index));
            }
            return View(fonte);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var fonte = await _fonteEnergiaRepository.GetByIdAsync(id.Value);
            if (fonte == null) return NotFound();

            return View(fonte);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _fonteEnergiaRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
