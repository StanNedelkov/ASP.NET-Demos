using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoardApp_Demo.Models;
using TaskBoardApp_Demo.Services.Contracts;

namespace TaskBoardApp_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IHomeService service;

        public HomeController(ILogger<HomeController> _logger, IHomeService _service)
        {
            logger = _logger;
            service = _service;
        }

        public IActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isLogedIn = this.User?.Identity?.IsAuthenticated ?? false;
            var homeModel = service.HomeViewAsync(userId, isLogedIn);
            return View(homeModel);
        }

       
    }
}