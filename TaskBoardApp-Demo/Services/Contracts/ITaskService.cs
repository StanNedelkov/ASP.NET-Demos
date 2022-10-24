using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using TaskBoardApp_Demo.Models;

namespace TaskBoardApp_Demo.Services.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskBoardModel>> GetBoardsAsync();
        Task AddTaskAsync(TaskFormModel model, string userId);
        Task <TaskDetailsViewModel> GetTaskDetailsAsync(int taskId);

        Task<TaskFormModel> EditedTaskAsync(int taskId, string userId);

        Task EditTaskAsync(TaskFormModel model, string userId, int taskId);

        Task<TaskViewModel> TaskToDeleteAsync(int taskId, string userId);
        Task DeleteTaskAsync(TaskViewModel model, string userId);
    }
}
