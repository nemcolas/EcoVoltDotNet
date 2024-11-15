using EcoVolt.Models;
using EcoVolt.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcoVolt.Controllers
{
    public class ConsumidorController : Controller
    {
        private readonly IGsConsumidorService _gsConsumidorService;

        public ConsumidorController(IGsConsumidorService gsConsumidorService)
        {
            _gsConsumidorService = gsConsumidorService;
        }

        public async Task<IActionResult> Index()
        {
            var consumidores = await _gsConsumidorService.GetAllConsumidores();
            return View(consumidores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GsConsumidor consumidor)
        {
            if (ModelState.IsValid)
            {
                await _gsConsumidorService.AddConsumidor(consumidor);
                return RedirectToAction(nameof(Index));
            }
            return View(consumidor);
        }
    }
}