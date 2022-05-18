
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("categories")]
public class Category : Base.EntityName<int>
{
    public Category()
    {
        ProductCategories = new HashSet<ProductCategory>();
    }
    [Column("description")]
    public string? Description{ get; set; }
    [Column("image_url")]
    public string? ImageUrl{ get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }
}
