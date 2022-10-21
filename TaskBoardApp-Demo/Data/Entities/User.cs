using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp_Demo.Data.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(DataConstants.UserMaxFirstName)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(DataConstants.UserMaxLastName)]
        public string LastName { get; set; } = null!;
    }
}
