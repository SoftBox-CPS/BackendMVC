using System.ComponentModel.DataAnnotations;

namespace SoftBox.DataBase.Entities
{
    public class Chat : Base.EntitiesName<Guid>
    {
        public Chat()
        {
            ChatUsers = new HashSet<ChatUser>();
        }

        public string? Description { get; set; }
        public ICollection<ChatUser> ChatUsers { get; set; }

    }
}
