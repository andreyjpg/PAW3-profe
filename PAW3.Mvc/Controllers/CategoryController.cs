using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using System.Text.Json;

namespace PAW3.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public CategoryController(ILogger<CategoryController> logger, IServiceLocatorService serviceLocator, IServiceMapper serviceMapper)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _serviceMapper = serviceMapper;
        }

        // READ
        public async Task<IActionResult> Index()
        {
            var categories = await _serviceLocator.GetDataAsync<CategoryDTO>("category");
            var categoryViewModel = new CategoryViewModel()
            {
                Categories = categories
            };
            return View(categoryViewModel);
        }

        // CREATE
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(category);
                var success = await _serviceLocator.SaveDataAsync("category", json);

                if (success)
                    return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        //EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await _serviceLocator.GetDataAsync<CategoryDTO>("category");
            var category = categories.FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(string id, CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(category);
                var success = await _serviceLocator.UpdateDataAsync("category", id, json);

                if (success)
                    return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        //DELETE
        public async Task<IActionResult> Delete(string id)
        {
            var success = await _serviceLocator.SaveDataAsync("category", id);

            if (!success)
                _logger.LogWarning($"Failed to delete category with ID {id}");

            return RedirectToAction(nameof(Index));
        }

    }
}
