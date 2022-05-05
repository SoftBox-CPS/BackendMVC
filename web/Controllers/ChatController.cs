using Microsoft.AspNetCore.Mvc;
using SoftBox.DataBase.Repository;
using SoftBox.DataBase.Entities;

namespace MVCWebApplication.Controllers
{
    public class ChatController : Controller
    {
        private ChatRepository chatRepository;
        public ChatController(ChatRepository chatRepository)
        {
            this.chatRepository = chatRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users =  await chatRepository.GetAllUser();
            return View(users);
        }

        public async Task<IActionResult> AllChat(Guid user)
        {
            var chats = await chatRepository.GetAll();
            return View(chats);
        }

        [HttpGet("[controller]/RedirectToChat/{chat:Guid}")]
        public async Task<IActionResult> RedirectToChat(Guid chat)
        {
            
            return Redirect($"{Request.Headers["Referer"]}/{chat}");
        }
        [HttpGet("[controller]/AllChat/{userId:Guid}/{chatId:Guid}")]
        public async Task<IActionResult> Chat(Guid userId, Guid chatId)
        {
            var chat = await chatRepository.GetChatUser(chatId);
            ViewBag.ChatUser = chat.ChatUsers.FirstOrDefault(i => i.UserId == userId);
            return base.View((object)chat.ChatUsers);
        }
    }
}
