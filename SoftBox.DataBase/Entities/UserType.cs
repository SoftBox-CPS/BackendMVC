using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("user_types")]
public class UserType : Base.EntityName<int>
{ 
    public UserType()
    {
        Users = new HashSet<User>();
    }

    public virtual ICollection<User> Users { get; set; }
}
