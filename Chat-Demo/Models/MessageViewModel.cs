using System.ComponentModel.DataAnnotations;

namespace Chat_Demo.Models
{
    public class MessageViewModel
    {
        [Required(ErrorMessage ="Username can't be empty")]
        public string Sender { get; set; } = null!;
        [Required(ErrorMessage = "Message can't be empty")]
        public string MessageText { get; set; } = null!;
    }
}
