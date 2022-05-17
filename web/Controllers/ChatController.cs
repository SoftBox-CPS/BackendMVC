using Microsoft.AspNetCore.Mvc;
using SoftBox.DataBase.Repository;
using SoftBox.DataBase.Entities;
using System.Linq;

namespace MVCWebApplication.Controllers;

[Route("[controller]")]
public class ChatController : Base.EntityController<SoftBox.DataBase.Entities.Room, Guid>
{
    private RoomRepository chatRepository;
    public ChatController(RoomRepository chatRepository) : base(chatRepository)
    {
        this.chatRepository = chatRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var users = await chatRepository.GetAllUser();
        return View(users);
    }

    [HttpGet("AllChat")]
    public async Task<IActionResult> AllChat(Guid user)
    {
        var chats = await repository.GetAll();
        return View(chats);
    }

    [HttpGet("RedirectToChat/{chat:Guid}")]
    public IActionResult RedirectToChat(Guid chat)
    {
        var refURL = Request.Headers["Referer"].ToString();
        var userId = new Uri(refURL).Query.Split('=')[1];

        return Redirect($"{userId}/{chat}");
    }
    [HttpGet("RedirectToChat/{userId:Guid}/{chatId:Guid}")]
    public async Task<IActionResult> Chat(Guid userId, Guid chatId)
    {
        var chat = await chatRepository.GetRoomUser(chatId);
        ViewBag.ChatUser = chat.RoomUsers.FirstOrDefault(i => i.UserId == userId);
        return base.View((object)chat.RoomUsers);
    }
}
