using Microsoft.EntityFrameworkCore;
using TaskBoardApp_Demo.Data;
using TaskBoardApp_Demo.Models;
using TaskBoardApp_Demo.Services.Contracts;

namespace TaskBoardApp_Demo.Services
{
    public class BoardsService : IBoardsService
    {
        private readonly TaskBoardAppDbContext context;
        public BoardsService(TaskBoardAppDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IEnumerable<BoardViewModel>> GetBoardAsync()
        {
            var boards = await context
                .Boards
                .Select(x => new BoardViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Tasks = x.Tasks
                    .Select(t=> new TaskViewModel()
                    {
                        Id = t.Id,
                        Description = t.Description,
                        Owner = t.Owner.UserName,
                        Title = t.Title
                    })
                })
                .ToListAsync();
            
            return boards;
        }
    }
}
