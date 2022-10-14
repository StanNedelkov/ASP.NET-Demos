using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Models;
using System.Diagnostics;

namespace MVC_Demo.Controllers
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
            ViewBag.Message = "This is a MVC Demo";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is a basic ASP.NET Core MVC demo app.";
            return View();
        }
        public IActionResult Numbers()
        {
            ViewBag.Message = "Theese are the numbers 1 to 50.";
            return View();
        }

        public IActionResult NumbersToN(int count = 2)
        {
            ViewBag.Message = "Please enter a number";
            ViewBag.Count = count;
            return View();
        }
    }
}