using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp_Demo.Data.Entities
{
    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.BoarMaxName)]
        public string Name { get; set; } = null!;
        public ICollection<Task> Tasks { get; set; }
    }
}
