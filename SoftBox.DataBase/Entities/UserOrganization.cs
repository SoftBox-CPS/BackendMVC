
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("user_organizations")]
public class UserOrganization : Base.Entity<Guid>
{
    public UserOrganization()
    {
        StartDateTimeOffset = DateTimeOffset.Now; 
    }

    [Required]
    [Column("start_date_time_offset")]
    public DateTimeOffset StartDateTimeOffset { get; set; }
    [Column("end_date_time_offset")]
    public DateTimeOffset? EndDateTimeOffset { get; set; }

    [Required]
    [Column("user_id")]
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User User { get; set; }

    [Required]
    [Column("user_organization_type_id")]
    [ForeignKey(nameof(UserOrganizationType))]
    public int UserOrganizationTypeId { get; set; }
    public UserOrganizationType UserOrganizationType { get; set; }

    [Required]
    [Column("organization_id")]
    [ForeignKey(nameof(Organization))]
    public Guid OrganizationId { get; set; }
    public Organization Organization { get; set; }
}
