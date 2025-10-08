using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.Mvc.Models;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;

namespace PAW3.Mvc.Controllers
{
    public class UserActionController : Controller
    {
        private readonly ILogger<UserActionController> _logger;
        private readonly IServiceLocatorService _serviceLocator;
        private readonly IServiceMapper _serviceMapper;

        public UserActionController(ILogger<UserActionController> logger, IServiceLocatorService serviceLocator, IServiceMapper serviceMapper)
        {
            _logger = logger;
            _serviceLocator = serviceLocator;
            _serviceMapper = serviceMapper;
        }

        public async Task<IActionResult> Index()
        {
            var userActions = await _serviceLocator.GetDataAsync<UserActionDTO>("userAction");
            var categoryViewModel = new UserActionViewModel()
            {
                UserActions = userActions
            };
            return View(categoryViewModel);
        }
    }
}
