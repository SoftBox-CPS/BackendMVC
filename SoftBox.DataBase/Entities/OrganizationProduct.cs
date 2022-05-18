

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("organization_products")]
[Index(nameof(ProductId), nameof(OrganizationId), IsUnique = true)]
public class OrganizationProduct : Base.Entity<Guid>
{

    public OrganizationProduct()
    {
        Rooms = new HashSet<Room>();
    }

    [Required]
    [Column("organization_id")]
    [ForeignKey(nameof(Organization))]
    public Guid OrganizationId { get; set; }
    public Organization Organization { get; set; }

    [Required]
    [Column("product_id")]
    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    [Column("price", TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public ICollection<Room> Rooms { get; set; }
}
