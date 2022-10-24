using TaskBoardApp_Demo.Data;
using TaskBoardApp_Demo.Models;
using TaskBoardApp_Demo.Services.Contracts;

namespace TaskBoardApp_Demo.Services
{
    public class HomeService : IHomeService
    {
        private readonly TaskBoardAppDbContext context;
        public HomeService(TaskBoardAppDbContext _context)
        {
            this.context = _context;
        }

        public HomeViewModel HomeViewAsync(string userId, bool isLogedIn)
        {
            var taskBoards = context
                .Boards
                .Select(x => x.Name)
                .Distinct();
            var tasksCount = new List<HomeBoardModel>();

            foreach (var taskName in taskBoards)
            {
                int tasksInBoard = context
                    .Tasks
                    .Where(x => x.Board.Name == taskName)
                    .Count();
                tasksCount.Add(new HomeBoardModel()
                {
                    TasksCount = tasksInBoard,
                    BoardName = taskName
                });
            }

            int userTaskCount = -1;

            if (isLogedIn)
            {
                userTaskCount = context
                    .Tasks
                    .Where(x => x.OwnerId == userId)
                    .Count();
            }

            var homeViewModel = new HomeViewModel()
            {
                AllTasksCount = context.Tasks.Count(),
                BoardsWithTaskCount = tasksCount,
                UserTasksCount = userTaskCount

            };

            return homeViewModel;
        }
    }
}
