using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftBox.DataBase.Entities;

[Table("users")]
public class User : Base.Entity<Guid>
{
    public User()
    {
        ChatUsers = new HashSet<RoomUser>();
        UserOrganizations = new HashSet<UserOrganization>();
    }
    [Required]
    [Column("login")]
    public string Login { get; set; }
    [Required]
    [Column("password_hash")]
    public string PasswordHash { get; set; }

    [Required]
    [Column("first_name")]
    public string FirstName { get; set; }
    [Required]
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("patronymic")]
    public string? Patronymic { get; set; }

    [Required]
    [Column("phone")]
    [MaxLength(20)]
    public string Phone { get; set; }
    [Required]
    [Column("email")]
    [MaxLength(254)]
    public string Email { get; set; }

    [Required]
    [Column("user_type_id")]
    [ForeignKey(nameof(UserType))]
    public int UserTypeId { get; set; }
    public UserType UserType { get; set; }

    public ICollection<RoomUser> ChatUsers { get; set; }
    public ICollection<UserOrganization> UserOrganizations { get; set; }

}
