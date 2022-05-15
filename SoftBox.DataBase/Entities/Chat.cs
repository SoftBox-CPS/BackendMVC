using System.ComponentModel.DataAnnotations;

namespace SoftBox.DataBase.Entities
{
    public class Chat : Base.EntityName<Guid>
    {
        public Chat()
        {
            ChatUsers = new HashSet<ChatUser>();
        }

        public string? Description { get; set; }
        public ICollection<ChatUser> ChatUsers { get; set; }

    }
}
