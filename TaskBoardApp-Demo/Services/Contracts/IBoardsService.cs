using TaskBoardApp_Demo.Models;

namespace TaskBoardApp_Demo.Services.Contracts
{
    public interface IBoardsService
    {
        Task<IEnumerable<BoardViewModel>> GetBoardAsync();
    }
}
