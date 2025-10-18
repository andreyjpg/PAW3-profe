using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using System.Text.Json;

namespace PAW3.Mvc.Controllers
{
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public TaskController(ILogger<TaskController> logger, IServiceLocatorService serviceLocator, IServiceMapper serviceMapper)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _serviceMapper = serviceMapper;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _serviceLocator.GetDataAsync<TaskDTO>("task");
            var taskViewModel = new TaskViewModel()
            {
                Tasks = tasks
            };
            return View(taskViewModel);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(TaskDTO dto)
        {
            if (ModelState.IsValid)
            {
                dto.CreatedAt = DateTime.Now;
                var json = JsonSerializer.Serialize(dto);
                var success = await _serviceLocator.SaveDataAsync("task", json);

                if (success)
                    return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        //EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await _serviceLocator.GetDataAsync<TaskDTO>("task");
            var task = categories.FirstOrDefault(c => c.Id == id);

            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskDTO task)
        {
            if (ModelState.IsValid)
            {
                task.LastModified = DateTime.Now;
                task.ModifiedBy = "MVC";
                var json = JsonSerializer.Serialize(task);
                var success = await _serviceLocator.UpdateDataAsync("task", json);

                if (success)
                    return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        //DELETE
        public async Task<IActionResult> Delete(string id)
        {
            var success = await _serviceLocator.DeleteDataAsync("task", id);

            if (!success)
                _logger.LogWarning($"Failed to delete task with ID {id}");

            return RedirectToAction(nameof(Index));
        }
    }
}
