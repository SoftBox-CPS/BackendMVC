using System.ComponentModel.DataAnnotations;

namespace SoftBox.DataBase.Entities.Base;

public abstract class EntityName<T> : Entity<T>, InterfacesEntities.INamedEntity<T>
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
}
