using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities.Base;

public abstract class Entity<T> : InterfacesEntities.IEntity<T>
{
    [Key]
    [Column("id")]
    public T Id { get; set; }
}

