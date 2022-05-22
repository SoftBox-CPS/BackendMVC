
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("user_organization_types")]
public class UserOrganizationType : Base.EntityName<int>
{
    public UserOrganizationType()
    {
        UserOrganizations = new HashSet<UserOrganization>();

    }

    public ICollection<UserOrganization> UserOrganizations { get; set; }
}
