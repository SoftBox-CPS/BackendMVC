
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Index(nameof(ProductId), nameof(CategoryId), IsUnique =true)]
[Table("product_categories")]
public class ProductCategory : Base.Entity<Guid>
{
    [Required]
    [Column("product_id")]
    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    [Column("category_id")]
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
