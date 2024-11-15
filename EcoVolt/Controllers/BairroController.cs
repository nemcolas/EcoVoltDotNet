using Microsoft.AspNetCore.Mvc;

namespace EcoVolt.Controllers;

public class BairroController : Controller
{
    private readonly IBairroRepository _bairroRepository;

    public BairroController(IBairroRepository bairroRepository)
    {
        _bairroRepository = bairroRepository;
    }

    public async Task<IActionResult> Index()
    {
        var bairros = await _bairroRepository.GetAllAsync();
        return View(bairros);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var bairro = await _bairroRepository.GetByIdAsync(id.Value);
        if (bairro == null) return NotFound();

        return View(bairro);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Nome, CodCidade")] Bairro bairro)
    {
        if (ModelState.IsValid)
        {
            await _bairroRepository.AddAsync(bairro);
            return RedirectToAction(nameof(Index));
        }
        return View(bairro);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var bairro = await _bairroRepository.GetByIdAsync(id.Value);
        if (bairro == null) return NotFound();

        return View(bairro);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, Nome, CodCidade")] Bairro bairro)
    {
        if (id != bairro.Id) return NotFound();

        if (ModelState.IsValid)
        {
            await _bairroRepository.UpdateAsync(bairro);
            return RedirectToAction(nameof(Index));
        }
        return View(bairro);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var bairro = await _bairroRepository.GetByIdAsync(id.Value);
        if (bairro == null) return NotFound();

        return View(bairro);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _bairroRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}