using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using System.Text.Json;

namespace PAW3.Mvc.Controllers
{
    public class UserActionController : Controller
    {
        private readonly ILogger<UserActionController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public UserActionController(
            ILogger<UserActionController> logger,
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
            var actions = await _serviceLocator.GetDataAsync<UserActionDTO>("userAction");
            var vm = new UserActionViewModel
            {
                UserActions = actions
            };
            return View(vm);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserActionDTO dto)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(dto);
                var ok = await _serviceLocator.SaveDataAsync("userAction", json);
                if (ok) return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actions = await _serviceLocator.GetDataAsync<UserActionDTO>("userAction");
            var action = actions.FirstOrDefault(a => a.Id == id);
            if (action == null) return NotFound();
            return View(action);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserActionDTO dto)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(dto);
                var ok = await _serviceLocator.UpdateDataAsync("userAction", json);
                if (ok) return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // DELETE
        public async Task<IActionResult> Delete(string id)
        {
            var ok = await _serviceLocator.DeleteDataAsync("userAction", id);
            if (!ok)
                _logger.LogWarning($"Failed to delete user action with ID {id}");

            return RedirectToAction(nameof(Index));
        }
    }
}