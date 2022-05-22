using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("room_user_types")]
public class RoomUserType : Base.EntityName<int>
{
    public RoomUserType()
    {
        RoomUsers = new HashSet<RoomUser>();
    }

    public virtual ICollection<RoomUser> RoomUsers { get; set; }
}
