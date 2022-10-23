using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp_Demo.Services.Contracts;

namespace TaskBoardApp_Demo.Controllers
{
    [Authorize]
    public class BoardsController : Controller
    {
        private readonly IBoardsService service;
        public BoardsController(IBoardsService _service)
        {
            this.service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View(await service.GetBoardAsync());
        }
    }
}
