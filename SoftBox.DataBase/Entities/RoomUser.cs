using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Index(nameof(UserId), nameof(RoomId), IsUnique = true)]
[Table("room_users")]
public class RoomUser : Base.Entity<Guid>
{
    public RoomUser()
    {
        RoomMessages = new HashSet<RoomMessage>();
    }
    [Required]
    [Column("user_id")]
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User User { get; set; }

    [Required]
    [Column("room_id")]
    [ForeignKey(nameof(Room))]
    public Guid RoomId { get; set; }
    public Room Room { get; set; }

    [Required]
    [Column("room_user_type_id")]
    [ForeignKey(nameof(RoomUserType))]
    public int RoomUserTypeID { get; set; }
    public RoomUserType RoomUserType { get; set; }

    [Required]
    [Column("amount_product")]
    public int AmountProduct { get; set; }

    public virtual ICollection<RoomMessage> RoomMessages { get; set; }
}
