namespace MVCWebApplication.Models
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string? FIO { get; set; }
        public string? Password { get; set; }
        public int Phone { get; set; }
        //UserType
        public string? UserType { get; set; }
        //Organization
        public Guid OrganizationId { get; set; }
        public string? Title { get; set; }
        public string? LegalName { get; set; }

    }
}
