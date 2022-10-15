using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSplitterApp_Demo.Models;

namespace TextSplitterApp_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index(TextViewModel textViewModel)
        {
            ModelState.Clear();
           
            return View(textViewModel);
        }

        [HttpPost]
        public IActionResult Split(TextViewModel textViewModel)
        {
            var splitText = textViewModel
                .Text.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            textViewModel.SplitText = string.Join(Environment.NewLine, splitText);

            return RedirectToAction(nameof(Index), textViewModel);
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
    }
}