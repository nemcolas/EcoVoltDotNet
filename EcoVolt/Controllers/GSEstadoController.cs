using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoVolt.Controllers;

public class GsEstadoController : Controller
{
    private readonly IGsEstadoRepository _estadoRepository;

    public GsEstadoController(IGsEstadoRepository estadoRepository)
    {
        _estadoRepository = estadoRepository;
    }

    public async Task<IActionResult> Index()
    {
        var estados = await _estadoRepository.GetAllAsync();
        return View(estados);
    }

    public async Task<IActionResult> Details(int id)
    {
        var estado = await _estadoRepository.GetByIdAsync(id);
        if (estado == null)
        {
            return NotFound();
        }
        return View(estado);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GsEstado estado)
    {
        if (ModelState.IsValid)
        {
            await _estadoRepository.AddAsync(estado);
            return RedirectToAction(nameof(Index));
        }
        return View(estado);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var estado = await _estadoRepository.GetByIdAsync(id);
        if (estado == null)
        {
            return NotFound();
        }
        return View(estado);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, GsEstado estado)
    {
        if (id != estado.CodEstado)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _estadoRepository.UpdateAsync(estado);
            return RedirectToAction(nameof(Index));
        }
        return View(estado);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var estado = await _estadoRepository.GetByIdAsync(id);
        if (estado == null)
        {
            return NotFound();
        }
        return View(estado);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _estadoRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}