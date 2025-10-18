using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using System.Text.Json;

namespace PAW3.Mvc.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public SupplierController(
            ILogger<SupplierController> logger,
            IServiceLocatorService serviceLocator,
            IServiceMapper serviceMapper)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _serviceMapper = serviceMapper;
        }

        // READ
        public async Task<IActionResult> Index()
        {
            var suppliers = await _serviceLocator.GetDataAsync<SupplierDTO>("supplier");
            var vm = new SupplierViewModel
            {
                Suppliers = suppliers
            };
            return View(vm);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto.LastModified ??= DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");
                dto.ModifiedBy ??= "System";

                var json = JsonSerializer.Serialize(dto);
                var ok = await _serviceLocator.SaveDataAsync("supplier", json);
                if (ok) return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var suppliers = await _serviceLocator.GetDataAsync<SupplierDTO>("supplier");
            var supplier = suppliers.FirstOrDefault(s => s.SupplierId == id);
            if (supplier == null) return NotFound();
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SupplierDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto.LastModified = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");

                var json = JsonSerializer.Serialize(dto);
                var ok = await _serviceLocator.UpdateDataAsync("supplier", json);
                if (ok) return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // DELETE
        public async Task<IActionResult> Delete(string id)
        {
            var ok = await _serviceLocator.DeleteDataAsync("supplier", id);
            if (!ok)
                _logger.LogWarning($"Failed to delete supplier with ID {id}");

            return RedirectToAction(nameof(Index));
        }
    }
}
