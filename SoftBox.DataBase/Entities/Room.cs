using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("rooms")]
public class Room : Base.EntityName<Guid>
{
    public Room()
    {
        RoomUsers = new HashSet<RoomUser>();
    }

    [Required]
    [Column("product_id")]
    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    [Column("amount_product")]
    public int AmountProduct { get; set; }
    [Required]
    [Column("price", TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column("description")]
    public string? Description { get; set; }
    public ICollection<RoomUser> RoomUsers { get; set; }

}
