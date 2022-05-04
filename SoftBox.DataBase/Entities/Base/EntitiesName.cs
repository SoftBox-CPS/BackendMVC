using System.ComponentModel.DataAnnotations;

namespace SoftBox.DataBase.Entities.Base
{
    public abstract class EntitiesName<T> : Entities<T>, InterfacesEntities.INamedEntities<T>
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
