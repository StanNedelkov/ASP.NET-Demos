using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp_Demo.Models
{
    public class HomeBoardModel
    {
        [Required]
        public string BoardName { get; init; } = null!;
        [Required]
        public int TasksCount { get; init; }
    }
}
