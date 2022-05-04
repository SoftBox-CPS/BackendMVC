using Microsoft.AspNetCore.Identity;

namespace SoftBox.DataBase.Entities;

public class User : IdentityUser
{
    public User()
    {
        ChatUsers = new HashSet<ChatUser>();
    }
    // User Profile
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }

    //Organization
    public Guid OrganizationId { get; set; }
    public string? Title { get; set; }
    public string? LegalName { get; set; }

    public long TypeUserId { get; set; }

    public ICollection<ChatUser> ChatUsers { get; set; }

}
