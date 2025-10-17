using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using System.Text.Json;

namespace PAW3.Mvc.Controllers
{
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public RoleController(
            ILogger<RoleController> logger,
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
            var roles = await _serviceLocator.GetDataAsync<RoleDTO>("role");
            var vm = new RoleViewModel
            {
                Roles = roles
            };
            return View(vm);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleDTO dto)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(dto);
                var ok = await _serviceLocator.SaveDataAsync("role", json);
                if (ok) return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var roles = await _serviceLocator.GetDataAsync<RoleDTO>("role");
            var role = roles.FirstOrDefault(r => r.RoleId == id);
            if (role == null) return NotFound();
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoleDTO dto)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(dto);
                var ok = await _serviceLocator.UpdateDataAsync("role", json);
                if (ok) return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // DELETE
        public async Task<IActionResult> Delete(string id)
        {
            var ok = await _serviceLocator.DeleteDataAsync("role", id);
            if (!ok)
                _logger.LogWarning($"Failed to delete role with ID {id}");

            return RedirectToAction(nameof(Index));
        }
    }
}
