using System.ComponentModel.DataAnnotations;

namespace SoftBox.DataBase.Entities
{
    public class Chat
    {
        public Chat()
        {
            ChatUsers = new HashSet<ChatUser>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public string? Description { get; set; }
        public ICollection<ChatUser> ChatUsers { get; set; }

    }
}
