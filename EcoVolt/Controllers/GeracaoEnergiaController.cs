using Microsoft.AspNetCore.Mvc;

namespace EcoVolt.Controllers;

public class GeracaoEnergiaController : Controller
{
    private readonly IGeracaoEnergiaRepository _geracaoEnergiaRepository;

    public GeracaoEnergiaController(IGeracaoEnergiaRepository geracaoEnergiaRepository)
    {
        _geracaoEnergiaRepository = geracaoEnergiaRepository;
    }

    public async Task<IActionResult> Index()
    {
        var geracoes = await _geracaoEnergiaRepository.GetAllAsync();
        return View(geracoes);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var geracao = await _geracaoEnergiaRepository.GetByIdAsync(id.Value);
        if (geracao == null) return NotFound();

        return View(geracao);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EnergiaGeradaKwh, Data, IdFonte")] GeracaoEnergia geracao)
    {
        if (ModelState.IsValid)
        {
            await _geracaoEnergiaRepository.AddAsync(geracao);
            return RedirectToAction(nameof(Index));
        }
        return View(geracao);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var geracao = await _geracaoEnergiaRepository.GetByIdAsync(id.Value);
        if (geracao == null) return NotFound();

        return View(geracao);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, EnergiaGeradaKwh, Data, IdFonte")] GeracaoEnergia geracao)
    {
        if (id != geracao.Id) return NotFound();

        if (ModelState.IsValid)
        {
            await _geracaoEnergiaRepository.UpdateAsync(geracao);
            return RedirectToAction(nameof(Index));
        }
        return View(geracao);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var geracao = await _geracaoEnergiaRepository.GetByIdAsync(id.Value);
        if (geracao == null) return NotFound();

        return View(geracao);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _geracaoEnergiaRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}