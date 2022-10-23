using Microsoft.EntityFrameworkCore;
using TaskBoardApp_Demo.Data;
using TaskBoardApp_Demo.Data.Entities;
using TaskBoardApp_Demo.Models;
using TaskBoardApp_Demo.Services.Contracts;
using System.Threading.Tasks;

namespace TaskBoardApp_Demo.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskBoardAppDbContext context;
        private const string taskNotFoundMessage = "Task Not Found";
        private const string wrongUser = "You don't have permission to edit this Task";
        public TaskService(TaskBoardAppDbContext _context)
        {
            context = _context;
        }

        public async System.Threading.Tasks.Task AddTaskAsync(TaskFormModel model, string userId)
        {
            var task = new Data.Entities.Task()
            {
                BoardId = model.BoardId,
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                OwnerId = userId,
            };

            await context.AddAsync(task);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskBoardModel>> GetBoardsAsync()
        {
            return await context.Boards
                .Select(x => new TaskBoardModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync();
        }

        public async Task<TaskDetailsViewModel> GetTaskDetailsAsync(int taskId)
        {
            var taskWithDetails = await context
                .Tasks
                .Where(x => x.Id == taskId)
                .Select(x => new TaskDetailsViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Title = x.Title,
                    CreatedOn = x.CreatedOn.ToString("g"),
                    Board = x.Board.Name,
                    Owner = x.Owner.UserName
                })
                .FirstOrDefaultAsync();

            if (taskWithDetails == null)
            {
                throw new ArgumentNullException(taskNotFoundMessage);
            }

            return taskWithDetails;
        }

        public async Task<TaskFormModel> EditedTaskAsync(int taskId, string userId)
        {
            var task = await context
                .Tasks
                .Include(x => x.Board)
                .FirstOrDefaultAsync(x => x.Id == taskId);
            if (task == null)
            {
                throw new ArgumentNullException(taskNotFoundMessage);
            }
            if (task.OwnerId != userId)
            {
                throw new UnauthorizedAccessException(wrongUser);
            }
            var model = new TaskFormModel()
            {
                Title = task.Title,
                BoardId = task.BoardId,
                BoardStatuses = await this.GetBoardsAsync(),
                Description = task.Description,
            };

            return model;
        }

        public async System.Threading.Tasks.Task EditTaskAsync(TaskFormModel model, string userId, int taskId)
        {
            var editModel = await context
                .Tasks
                .FirstOrDefaultAsync(x => x.Id == taskId);

            if (editModel == null)
            {
                throw new ArgumentNullException(taskNotFoundMessage);
            }

            if (editModel?.OwnerId != userId)
            {
                throw new UnauthorizedAccessException(wrongUser);
            }

            editModel.Description = model.Description;
            editModel.Title = model.Title;
            editModel.BoardId = model.BoardId;
            await context.SaveChangesAsync();
        }
    }
}
