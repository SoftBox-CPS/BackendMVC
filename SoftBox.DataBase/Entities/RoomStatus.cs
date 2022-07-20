using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("room_statuses")]
public class RoomStatus : Base.EntityName<int>
{
    public RoomStatus()
    {
        Rooms = new HashSet<Room>();
    }
    public ICollection<Room> Rooms { get; set; }
}