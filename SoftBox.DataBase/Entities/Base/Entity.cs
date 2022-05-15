using System.ComponentModel.DataAnnotations;

namespace SoftBox.DataBase.Entities.Base;

public abstract class Entity<T> : InterfacesEntities.IEntity<T>
{
    [Key]
    public T Id { get; set; }
}

