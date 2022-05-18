using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("products")]
public class Product : Base.EntityName<Guid>
{
    public Product()
    {
        CreatedDateOffset = DateTimeOffset.Now;
        ProductCategories = new HashSet<ProductCategory>();
    }
    [Required]
    [Column("created_date_offset")]
    public DateTimeOffset CreatedDateOffset { get; set; }
    [Required]
    [Column("price", TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }
    [Column("image_url")]
    public string? ImageUrl { get; set; }

    public ICollection<ProductCategory> ProductCategories { get; set; }
}

