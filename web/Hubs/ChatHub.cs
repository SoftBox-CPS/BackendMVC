using Microsoft.AspNetCore.SignalR;
using SoftBox.DataBase.Repository;

namespace MVCWebApplication.Hubs
{
    public class ChatHub : Hub
    {
        private ChatRepository chatRepository;

        public ChatHub(ChatRepository chatRepository)
        {
            this.chatRepository = chatRepository;
        }

        public async Task EnterChat(Guid chatUserId)
        {
            var chatUser = await chatRepository.GetChatUserByChatUserId(chatUserId);
            await Groups.AddToGroupAsync(Context.ConnectionId, chatUser.ChatId.ToString());
        }
        public async Task SendMessage(Guid chatUserId, string message)
        {
            var chatUser = await chatRepository.GetChatUserByChatUserId(chatUserId);
            var dateTimeMessage = new DateTimeOffset(DateTime.Now);
            await chatRepository.AddChatMessage(
                new SoftBox.DataBase.Entities.ChatMessage()
                {
                    ChatUserID = chatUser.Id,
                    Message = message,
                    DateTimeUTCMessage = dateTimeMessage
                }
                );
            chatRepository.SaveChanges();
            await Clients.Group(chatUser.ChatId.ToString()).SendAsync("ReceiveMessage", chatUser.UserId, message, dateTimeMessage);
        }
    }
}
