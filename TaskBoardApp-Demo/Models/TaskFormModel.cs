using System.ComponentModel.DataAnnotations;
using TaskBoardApp_Demo.Data;
using TaskBoardApp_Demo.Data.Entities;

namespace TaskBoardApp_Demo.Models
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(DataConstants.TaskMaxTitle, MinimumLength = DataConstants.TaskMinTitle)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(DataConstants.TaskMaxDescription, MinimumLength = DataConstants.TaskMinDescription)]
        public string Description { get; set; } = null!;

        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> BoardStatuses { get; set; } = new List<TaskBoardModel>();
    }
}
