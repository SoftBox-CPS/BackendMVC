using Microsoft.AspNetCore.Mvc;
using SoftBox.DataBase.Entities;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using SoftBox.DataBase.InterfacesRepository;

namespace MVCWebApplication.Controllers;

[Route("[controller]")]
[Authorize]
public class ChatController : Base.EntityController<Room, Guid>
{
    private IRoomRepository chatRepository;
    public ChatController(IRoomRepository chatRepository) : base(chatRepository)
    {
        this.chatRepository = chatRepository;
    }

    [HttpGet]
    public async Task<IActionResult> AllChat()
    {
        var chats = await chatRepository.GetRoomByUserId(User.Claims.First(x => x.Type == "id").Value);
        return View(chats);
    }

    [HttpGet("{chatId:Guid}")]
    public async Task<IActionResult> Chat(Guid chatId)
    {
        var chat = await chatRepository.GetRoomUser(chatId);
        ViewBag.ChatUser = chat.RoomUsers.FirstOrDefault(i => i.UserId.ToString() == User.Claims.First(x => x.Type == "id").Value);
        return base.View(chat.RoomUsers);
    }
}
