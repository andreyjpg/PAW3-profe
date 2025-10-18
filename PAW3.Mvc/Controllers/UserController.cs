using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using System.Text.Json;

namespace PAW3.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public UserController(ILogger<UserController> logger, IServiceLocatorService serviceLocator, IServiceMapper serviceMapper)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _serviceMapper = serviceMapper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _serviceLocator.GetDataAsync<UserDTO>("user");
            var userViewModel = new UserViewModel()
            {
                Users = users
            };
            return View(userViewModel);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto.LastModified = DateTime.Now;
                dto.ModifiedBy = "MVC";
                var json = JsonSerializer.Serialize(dto);
                var success = await _serviceLocator.SaveDataAsync("user", json);

                if (success)
                    return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        //EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await _serviceLocator.GetDataAsync<UserDTO>("user");
            var user = categories.FirstOrDefault(c => c.UserId == id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                user.LastModified = DateTime.Now;
                user.ModifiedBy = "MVC";
                var json = JsonSerializer.Serialize(user);
                var success = await _serviceLocator.UpdateDataAsync("user", json);

                if (success)
                    return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        //DELETE
        public async Task<IActionResult> Delete(string id)
        {
            var success = await _serviceLocator.DeleteDataAsync("user", id);

            if (!success)
                _logger.LogWarning($"Failed to delete user with ID {id}");

            return RedirectToAction(nameof(Index));
        }
    }
}
