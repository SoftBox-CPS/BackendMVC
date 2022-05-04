using System.ComponentModel.DataAnnotations;

namespace SoftBox.DataBase.Entities
{
    public class ChatUserType : Base.EntitiesName<int>
    {
        public ChatUserType()
        {
            ChatUsers = new HashSet<ChatUser>();
        }

        public virtual ICollection<ChatUser> ChatUsers { get; set; }
    }
}
