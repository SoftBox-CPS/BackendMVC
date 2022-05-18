
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("organizations")]
public class Organization : Base.EntityName<Guid>
{
    public Organization()
    {
        UserOrganizations = new HashSet<UserOrganization>();
    }

    public ICollection<UserOrganization> UserOrganizations { get; set; }
}
