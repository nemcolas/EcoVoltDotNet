using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoVolt.Controllers;

public class GsCidadeController : Controller
{
    private readonly IGsCidadeRepository _cidadeRepository;

    public GsCidadeController(IGsCidadeRepository cidadeRepository)
    {
        _cidadeRepository = cidadeRepository;
    }

    public async Task<IActionResult> Index()
    {
        var cidades = await _cidadeRepository.GetAllAsync();
        return View(cidades);
    }

    public async Task<IActionResult> Details(int id)
    {
        var cidade = await _cidadeRepository.GetByIdAsync(id);
        if (cidade == null)
        {
            return NotFound();
        }
        return View(cidade);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GsCidade cidade)
    {
        if (ModelState.IsValid)
        {
            await _cidadeRepository.AddAsync(cidade);
            return RedirectToAction(nameof(Index));
        }
        return View(cidade);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cidade = await _cidadeRepository.GetByIdAsync(id);
        if (cidade == null)
        {
            return NotFound();
        }
        return View(cidade);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, GsCidade cidade)
    {
        if (id != cidade.CodCidade)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _cidadeRepository.UpdateAsync(cidade);
            return RedirectToAction(nameof(Index));
        }
        return View(cidade);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var cidade = await _cidadeRepository.GetByIdAsync(id);
        if (cidade == null)
        {
            return NotFound();
        }
        return View(cidade);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _cidadeRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}