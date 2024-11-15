using Microsoft.AspNetCore.Mvc;

namespace EcoVolt.Controllers;

public class ConsumoEnergiaController : Controller
{
    private readonly IConsumoEnergiaRepository _consumoEnergiaRepository;

    public ConsumoEnergiaController(IConsumoEnergiaRepository consumoEnergiaRepository)
    {
        _consumoEnergiaRepository = consumoEnergiaRepository;
    }

    public async Task<IActionResult> Index()
    {
        var consumos = await _consumoEnergiaRepository.GetAllAsync();
        return View(consumos);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var consumo = await _consumoEnergiaRepository.GetByIdAsync(id.Value);
        if (consumo == null) return NotFound();

        return View(consumo);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EnergiaConsumidaKwh, Data, IdConsumidor")] ConsumoEnergia consumo)
    {
        if (ModelState.IsValid)
        {
            await _consumoEnergiaRepository.AddAsync(consumo);
            return RedirectToAction(nameof(Index));
        }
        return View(consumo);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var consumo = await _consumoEnergiaRepository.GetByIdAsync(id.Value);
        if (consumo == null) return NotFound();

        return View(consumo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, EnergiaConsumidaKwh, Data, IdConsumidor")] ConsumoEnergia consumo)
    {
        if (id != consumo.Id) return NotFound();

        if (ModelState.IsValid)
        {
            await _consumoEnergiaRepository.UpdateAsync(consumo);
            return RedirectToAction(nameof(Index));
        }
        return View(consumo);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var consumo = await _consumoEnergiaRepository.GetByIdAsync(id.Value);
        if (consumo == null) return NotFound();

        return View(consumo);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _consumoEnergiaRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}