using System.ComponentModel.DataAnnotations;

namespace SoftBox.DataBase.Entities.Base
{
    public abstract class Entities<T> : IntarfaceEntities.IEntities<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
