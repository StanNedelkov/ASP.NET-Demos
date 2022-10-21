using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskBoardApp_Demo.Models;

namespace TaskBoardApp_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

       
    }
}