using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp_Demo.Models;
using TaskBoardApp_Demo.Services.Contracts;

namespace TaskBoardApp_Demo.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ITaskService service;
        public TasksController(ITaskService _service)
        {
            this.service = _service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var board = await service.GetBoardsAsync();
            TaskFormModel model = new TaskFormModel()
            {
                BoardStatuses = board
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View(model);
            }

            var boards = await service.GetBoardsAsync();
            if (!boards.Any(x => x.Id == model.BoardId))
            {
                this.ModelState.AddModelError(string.Empty, "Board does not exist.");
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await service.AddTaskAsync(model, userId);   
            return RedirectToAction("All","Boards");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var taskWithDetails = await service.GetTaskDetailsAsync(id);
                return View(taskWithDetails);
            }
            catch (ArgumentNullException ae)
            {
                return BadRequest(ae.Message);
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                var taskToEdit = await service.EditedTaskAsync(id, userId);  
                return View(taskToEdit);
            }
            catch (ArgumentNullException ae)
            {
                return BadRequest(ae.Message);
            }
            catch(UnauthorizedAccessException ue)
            {
                return Unauthorized(ue.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View(model);
            }
            var boards = await service.GetBoardsAsync();
            if (!boards.Any(x => x.Id == model.BoardId))
            {
                this.ModelState.AddModelError(string.Empty, "Board does not exist.");
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await service.EditTaskAsync(model, userId, id);
                return RedirectToAction("All", "Boards");
            }
            catch (ArgumentNullException ae)
            {
                return BadRequest(ae.Message);
            }
            catch(UnauthorizedAccessException ua)
            {
                return Unauthorized(ua.Message);
            }
            
        }
    }
}
