using Microsoft.AspNetCore.SignalR;
using SoftBox.DataBase.Repository;

namespace MVCWebApplication.Hubs
{
    public class ChatHub : Hub
    {
        private RoomRepository chatRepository;

        public ChatHub(RoomRepository chatRepository)
        {
            this.chatRepository = chatRepository;
        }

        public async Task EnterChat(Guid chatUserId)
        {
            var chatUser = await chatRepository.GetRoomUserByRoomUserId(chatUserId);
            await Groups.AddToGroupAsync(Context.ConnectionId, chatUser.RoomId.ToString());
        }
        public async Task SendMessage(Guid chatUserId, string message)
        {
            var chatUser = await chatRepository.GetRoomUserByRoomUserId(chatUserId);
            var dateTimeMessage = new DateTimeOffset(DateTime.Now);
            await chatRepository.AddRoomMessage(
                new SoftBox.DataBase.Entities.RoomMessage()
                {
                    RoomUserId = chatUser.Id,
                    Message = message,
                    DateTimeUTCMessage = dateTimeMessage
                }
                );
            chatRepository.SaveChanges();
            await Clients.Group(chatUser.RoomId.ToString()).SendAsync("ReceiveMessage", chatUser.UserId, message, dateTimeMessage);
        }
    }
}
