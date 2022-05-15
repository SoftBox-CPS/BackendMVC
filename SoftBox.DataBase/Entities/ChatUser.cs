using System.ComponentModel.DataAnnotations;

namespace SoftBox.DataBase.Entities
{
    public class ChatUser : Base.Entity<Guid>
    {
        public ChatUser()
        {
            ChatMessages = new HashSet<ChatMessage>();
        }
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }
        [Required]
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }
        [Required]
        public int ChatUserTypeID { get; set; }
        public ChatUserType ChatUserType { get; set; }

        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
    }
}
