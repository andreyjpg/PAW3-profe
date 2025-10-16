using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using System.Diagnostics;
using System.Text.Json;

namespace PAW3.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public HomeController(ILogger<HomeController> logger, IServiceLocatorService serviceLocator, IServiceMapper serviceMapper)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _serviceMapper = serviceMapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _serviceLocator.GetDataAsync<ProductDTO>("product");
            var homeViewModel = new HomeViewModel()
            {
                Products = products
            };
            return View(homeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO productDTO)
        {
            // CODIGO PLACEHOLDER
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Datos inválidos.";
                return RedirectToAction(nameof(Index));
            }

            var json = JsonSerializer.Serialize(productDTO);
            var ok = await ((ServiceLocatorService)_serviceLocator).SaveDataAsync(json);

            TempData[ok ? "Ok" : "Error"] = ok ? "Producto creado." : "No se pudo crear el producto.";
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
