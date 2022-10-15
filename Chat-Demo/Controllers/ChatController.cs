using Chat_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat_Demo.Controllers
{
    /// <summary>
    /// Warning: this code holds the shared app data in a static field in the controller class. 
    /// This is just for this demo, and it is generally a bad practice! 
    /// Use a database or other persistent storage to hold data, 
    /// which should survive between the app requests and should be shared between all app users.
    /// </summary>
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> chats = 
            new List<KeyValuePair<string, string>>();

        public IActionResult Show()
        {
            if (chats == null)
            {
                return View(new ChatViewModel());
            }

            var chatModels = new ChatViewModel()
            {
                Messages = chats.Select(x => new MessageViewModel()
                {
                    Sender = x.Key,
                    MessageText = x.Value
                }).ToList()
            };

            return View(chatModels);
        }
        [HttpPost]
        public IActionResult Send(ChatViewModel _chat)
        {
            var newMessage = _chat.CurrentMessage;
            chats.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));
            return RedirectToAction(nameof(Show));
        }
    }
}
