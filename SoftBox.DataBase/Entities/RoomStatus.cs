using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("room_status")]
public class RoomStatus : Base.Entity<int>
{
    public string Title { get; set; }
    public ICollection<Room> Rooms { get; set; }
}