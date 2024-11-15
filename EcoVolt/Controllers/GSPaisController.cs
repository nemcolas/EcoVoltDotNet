using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoVolt.Controllers;

public class GsPaisController : Controller
{
    private readonly IGsPaisRepository _paisRepository;

    public GsPaisController(IGsPaisRepository paisRepository)
    {
        _paisRepository = paisRepository;
    }

    public async Task<IActionResult> Index()
    {
        var paises = await _paisRepository.GetAllAsync();
        return View(paises);
    }

    public async Task<IActionResult> Details(int id)
    {
        var pais = await _paisRepository.GetByIdAsync(id);
        if (pais == null)
        {
            return NotFound();
        }
        return View(pais);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GsPais pais)
    {
        if (ModelState.IsValid)
        {
            await _paisRepository.AddAsync(pais);
            return RedirectToAction(nameof(Index));
        }
        return View(pais);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var pais = await _paisRepository.GetByIdAsync(id);
        if (pais == null)
        {
            return NotFound();
        }
        return View(pais);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, GsPais pais)
    {
        if (id != pais.CodPais)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _paisRepository.UpdateAsync(pais);
            return RedirectToAction(nameof(Index));
        }
        return View(pais);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var pais = await _paisRepository.GetByIdAsync(id);
        if (pais == null)
        {
            return NotFound();
        }
        return View(pais);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _paisRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}