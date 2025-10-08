using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;

namespace PAW3.Mvc.Controllers
{
    public class ComponentController : Controller
    {
        private readonly ILogger<ComponentController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public ComponentController(ILogger<ComponentController> logger, IServiceLocatorService serviceLocator, IServiceMapper serviceMapper)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _serviceMapper = serviceMapper;
        }

        public async Task<IActionResult> Index()
        {
            var components = await _serviceLocator.GetDataAsync<ComponentDTO>("component");
            var categoryViewModel = new ComponentViewModel()
            {
                Components = components
            };
            return View(categoryViewModel);
        }
    }
}
