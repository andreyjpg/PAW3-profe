using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using System.Text.Json;

namespace PAW3.Mvc.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly ILogger<UserRoleController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public UserRoleController(ILogger<UserRoleController> logger, IServiceLocatorService serviceLocator, IServiceMapper serviceMapper)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _serviceMapper = serviceMapper;
        }

        public async Task<IActionResult> Index()
        {
            var userRoles = await _serviceLocator.GetDataAsync<UserRoleDTO>("userRole");
            var userRoleViewModel = new UserRoleViewModel()
            {
                UserRoles = userRoles
            };
            return View(userRoleViewModel);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(UserRoleDTO dto)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(dto);
                var success = await _serviceLocator.SaveDataAsync("userRole", json);

                if (success)
                    return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        //EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await _serviceLocator.GetDataAsync<UserRoleDTO>("userRole");
            var userRole = categories.FirstOrDefault(c => c.Id == id);

            if (userRole == null)
                return NotFound();

            return View(userRole);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserRoleDTO userRole)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(userRole);
                var success = await _serviceLocator.UpdateDataAsync("userRole", json);

                if (success)
                    return RedirectToAction(nameof(Index));
            }

            return View(userRole);
        }

        //DELETE
        public async Task<IActionResult> Delete(string id)
        {
            var success = await _serviceLocator.DeleteDataAsync("userRole", id);

            if (!success)
                _logger.LogWarning($"Failed to delete userRole with ID {id}");

            return RedirectToAction(nameof(Index));
        }
    }
}
