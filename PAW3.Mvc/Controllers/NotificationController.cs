using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using System.Text.Json;

namespace PAW3.Mvc.Controllers
{
    public class NotificationController : Controller
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public NotificationController(
            ILogger<NotificationController> logger,
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
            var notifications = await _serviceLocator.GetDataAsync<NotificationDTO>("notification");
            var vm = new NotificationViewModel
            {
                Notifications = notifications
            };
            return View(vm);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotificationDTO dto)
        {
            if (ModelState.IsValid)
            {
                // Si no se envía una fecha, la establecemos automáticamente
                if (dto.CreatedAt == default)
                    dto.CreatedAt = DateTime.UtcNow;

                var json = JsonSerializer.Serialize(dto);
                var ok = await _serviceLocator.SaveDataAsync("notification", json);
                if (ok) return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var notifications = await _serviceLocator.GetDataAsync<NotificationDTO>("notification");
            var notification = notifications.FirstOrDefault(n => n.Id == id);
            if (notification == null) return NotFound();
            return View(notification);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NotificationDTO dto)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(dto);
                var ok = await _serviceLocator.UpdateDataAsync("notification", json);
                if (ok) return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // DELETE
        public async Task<IActionResult> Delete(string id)
        {
            var ok = await _serviceLocator.DeleteDataAsync("notification", id);
            if (!ok)
                _logger.LogWarning($"Failed to delete notification with ID {id}");

            return RedirectToAction(nameof(Index));
        }
    }
}
