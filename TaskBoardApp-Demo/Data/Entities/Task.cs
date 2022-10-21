using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskBoardApp_Demo.Data.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.TaskMaxTitle)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(DataConstants.TaskMaxDescription)]
        public string Description  { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }
        [ForeignKey(nameof(BoardId))]
        public Board Board { get; set; }
        [Required]
        public string OwnerId { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public User Owner { get; set; }
    }
}
