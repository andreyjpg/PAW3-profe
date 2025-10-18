using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using System.Text.Json;

namespace PAW3.Mvc.Controllers
{
    public class ComponentController : Controller
    {
        private readonly ILogger<ComponentController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public ComponentController(
            ILogger<ComponentController> logger,
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
            var components = await _serviceLocator.GetDataAsync<ComponentDTO>("component");
            var vm = new ComponentViewModel
            {
                Components = components
            };
            return View(vm);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComponentDTO dto)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(dto);
                var ok = await _serviceLocator.SaveDataAsync("component", json);
                if (ok) return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(decimal id)
        {
            var components = await _serviceLocator.GetDataAsync<ComponentDTO>("component");
            var component = components.FirstOrDefault(c => c.Id == id);
            if (component == null) return NotFound();
            return View(component);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ComponentDTO dto)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(dto);
                var ok = await _serviceLocator.UpdateDataAsync("component", json);
                if (ok) return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // DELETE
        public async Task<IActionResult> Delete(string id)
        {
            var ok = await _serviceLocator.DeleteDataAsync("component", id);
            if (!ok) _logger.LogWarning($"Failed to delete component with ID {id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
