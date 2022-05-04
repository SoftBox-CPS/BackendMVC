using System.ComponentModel.DataAnnotations;

namespace SoftBox.DataBase.Entities
{
    public class ChatUserType
    {
        public ChatUserType()
        {
            ChatUsers = new HashSet<ChatUser>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<ChatUser> ChatUsers { get; set; }
    }
}
