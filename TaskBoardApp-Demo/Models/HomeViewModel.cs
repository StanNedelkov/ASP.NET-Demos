namespace TaskBoardApp_Demo.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            this.BoardsWithTaskCount = new List<HomeBoardModel>();
        }
        public int AllTasksCount { get; init; }

        public ICollection<HomeBoardModel> BoardsWithTaskCount { get; init; }
        public int UserTasksCount { get; init; }
    }
}
