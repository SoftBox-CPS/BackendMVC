using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("room_messages")]
public class RoomMessage : Base.Entity<Guid>
{  
    public RoomMessage()
    {
        CreateDateTimeOffset = DateTimeOffset.Now;
    }
    [Required]
    [Column("message")]
    public string Message { get; set; }

    [Required]
    [Column("room_user_id")]
    [ForeignKey(nameof(RoomUser))]
    public Guid RoomUserId { get; set; }
    public RoomUser RoomUser { get; set; }
    [Required]
    [Column("create_date_time_offset")]
    public DateTimeOffset CreateDateTimeOffset { get; set; }
}
