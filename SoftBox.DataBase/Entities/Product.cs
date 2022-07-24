using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("products")]
public class Product : Base.EntityName<Guid>
{
    public Product()
    {
        CreateDateTimeOffset = DateTimeOffset.Now;
        ProductCategories = new HashSet<ProductCategory>();
        Rooms = new HashSet<Room>();
    }
    [Required]
    [Column("create_date_time_offset")]
    public DateTimeOffset CreateDateTimeOffset { get; set; }
    [Required]
    [Column("price", TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Required]
    [Column("organization_id")]
    [ForeignKey(nameof(Organization))]
    public Guid OrganizationId { get; set; }
    public Organization Organization { get; set; }
    [Column("image_url")]
    public string? ImageUrl { get; set; }

    public ICollection<ProductCategory> ProductCategories { get; set; }
    public ICollection<Room> Rooms { get; set; }
}

