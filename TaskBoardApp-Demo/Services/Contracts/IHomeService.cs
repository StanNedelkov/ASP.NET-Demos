using TaskBoardApp_Demo.Models;

namespace TaskBoardApp_Demo.Services.Contracts
{
    public interface IHomeService
    {
        HomeViewModel HomeViewAsync(string userId, bool isLogedIn);
    }
}
