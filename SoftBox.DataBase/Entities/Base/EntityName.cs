using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities.Base;


public abstract class EntityName<T> : Entity<T>, InterfacesEntities.INamedEntity<T>
{
    [Required]
    [MaxLength(255)]
    [Column("name")]
    public string Name { get; set; }
}
