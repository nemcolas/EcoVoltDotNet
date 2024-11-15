using Microsoft.AspNetCore.Mvc;

namespace EcoVolt.Controllers;

public class DispositivoController : Controller
{
    private readonly IDispositivoRepository _dispositivoRepository;

    public DispositivoController(IDispositivoRepository dispositivoRepository)
    {
        _dispositivoRepository = dispositivoRepository;
    }

    public async Task<IActionResult> Index()
    {
        var dispositivos = await _dispositivoRepository.GetAllAsync();
        return View(dispositivos);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var dispositivo = await _dispositivoRepository.GetByIdAsync(id.Value);
        if (dispositivo == null) return NotFound();

        return View(dispositivo);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ConsumoEnergiaKwh, TipoDispositivo, IdConsumidor")] Dispositivo dispositivo)
    {
        if (ModelState.IsValid)
        {
            await _dispositivoRepository.AddAsync(dispositivo);
            return RedirectToAction(nameof(Index));
        }
        return View(dispositivo);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var dispositivo = await _dispositivoRepository.GetByIdAsync(id.Value);
        if (dispositivo == null) return NotFound();

        return View(dispositivo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, ConsumoEnergiaKwh, TipoDispositivo, IdConsumidor")] Dispositivo dispositivo)
    {
        if (id != dispositivo.Id) return NotFound();

        if (ModelState.IsValid)
        {
            await _dispositivoRepository.UpdateAsync(dispositivo);
            return RedirectToAction(nameof(Index));
        }
        return View(dispositivo);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var dispositivo = await _dispositivoRepository.GetByIdAsync(id.Value);
        if (dispositivo == null) return NotFound();

        return View(dispositivo);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _dispositivoRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}