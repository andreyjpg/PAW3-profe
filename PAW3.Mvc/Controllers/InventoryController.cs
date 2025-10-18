using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using System.Text.Json;

namespace PAW3.Mvc.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public InventoryController(
            ILogger<InventoryController> logger,
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
            var inventoryList = await _serviceLocator.GetDataAsync<InventoryDTO>("inventory");
            var vm = new InventoryViewModel
            {
                Inventories = inventoryList
            };
            return View(vm);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                // Si no viene definido, se setea automáticamente
                if (dto.DateAdded == default)
                    dto.DateAdded = DateTime.UtcNow;
                dto.modifiedBy = "MVC";
                dto.LastUpdate = DateTime.UtcNow;

                var json = JsonSerializer.Serialize(dto);
                var ok = await _serviceLocator.SaveDataAsync("inventory", json);
                if (ok) return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var inventoryList = await _serviceLocator.GetDataAsync<InventoryDTO>("inventory");
            var item = inventoryList.FirstOrDefault(i => i.InventoryId == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InventoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto.LastUpdate = DateTime.Now;
                dto.modifiedBy = "MVC";
                var json = JsonSerializer.Serialize(dto);
                var ok = await _serviceLocator.UpdateDataAsync("inventory", json);
                if (ok) return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // DELETE
        public async Task<IActionResult> Delete(string id)
        {
            var ok = await _serviceLocator.DeleteDataAsync("inventory", id);
            if (!ok)
                _logger.LogWarning($"Failed to delete inventory item with ID {id}");

            return RedirectToAction(nameof(Index));
        }
    }
}
