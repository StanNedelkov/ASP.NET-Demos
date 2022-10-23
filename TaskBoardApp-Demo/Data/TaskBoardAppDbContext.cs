using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp_Demo.Data.Entities;

namespace TaskBoardApp_Demo.Data
{
    public class TaskBoardAppDbContext : IdentityDbContext<User>
    {
        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }


        public DbSet<Board> Boards { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; } //Ambiguous call because of Task name.

        //Properties to seed the DB.

        private User GuestUser { get; set; }
        private Board OpenBoard { get; set; }
        private Board InProgressBoard { get; set; }
        private Board DoneBoard { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //This is how to restrict cascade delete. Good practice.
            builder
                .Entity<Entities.Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedUsers();
            builder.Entity<User>()
                .HasData(this.GuestUser);

            SeedBoards();
            builder.Entity<Board>()
                .HasData(this.OpenBoard, this.InProgressBoard, this.DoneBoard);

            builder.Entity<Entities.Task>()
                .HasData(new Entities.Task()
                {
                    Id = 1,
                    Title = "Prepare for ASP.NET exam",
                    Description = "Leard ASP.NET Identity",
                    CreatedOn = DateTime.Now.AddDays(-1),
                    OwnerId = this.GuestUser.Id,
                    BoardId = this.OpenBoard.Id,
                },
                new Entities.Task()
                {
                    Id = 2,
                    Title = "Improve EF Core skills",
                    Description = "Leard EF Core and MS SQL Server",
                    CreatedOn = DateTime.Now.AddDays(-10),
                    OwnerId = this.GuestUser.Id,
                    BoardId = this.OpenBoard.Id,
                },
                 new Entities.Task()
                 {
                     Id = 3,
                     Title = "Improve ASP.NET Core skills",
                     Description = "Leard good practices for ASP.NET Core Identity",
                     CreatedOn = DateTime.Now.AddMonths(-2),
                     OwnerId = this.GuestUser.Id,
                     BoardId = this.OpenBoard.Id,
                 },
                 new Entities.Task()
                 {
                     Id = 4,
                     Title = "Find a reason to live",
                     Description = "What makes you happy",
                     CreatedOn = DateTime.Now.AddYears(-1),
                     OwnerId = this.GuestUser.Id,
                     BoardId = this.OpenBoard.Id,
                 },
                 new Entities.Task()
                 {
                     Id = 5,
                     Title = "Check if DB works correctly",
                     Description = "Make new tasks in different status",
                     CreatedOn = DateTime.Now.AddYears(-1),
                     OwnerId = this.GuestUser.Id,
                     BoardId = this.InProgressBoard.Id,
                 },
                 new Entities.Task()
                 {
                     Id = 6,
                     Title = "Check if DB works correctly 2",
                     Description = "Make new tasks in different status",
                     CreatedOn = DateTime.Now.AddYears(-1),
                     OwnerId = this.GuestUser.Id,
                     BoardId = this.DoneBoard.Id,
                 }
                );

            base.OnModelCreating(builder);
        }

        private void SeedBoards()
        {
            this.OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };
            this.InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };
            this.DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            this.GuestUser = new User()
            {
                UserName = "Guest",
                NormalizedUserName = "GUEST",
                Email = "guest@gmail.com",
                NormalizedEmail = "GUEST@GMAIL.COM",
                FirstName = "Guest",
                LastName = "User"
            };
            this.GuestUser.PasswordHash = hasher.HashPassword(this.GuestUser, "guest");
        }
    }
}