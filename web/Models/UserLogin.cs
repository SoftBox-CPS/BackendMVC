using System.ComponentModel.DataAnnotations;

namespace MVCWebApplication.Models
{
    public class UserLogin
    {
        [Required]
        public Guid Id { get; set; }
        public string? FIO { get; set; }
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$",
            ErrorMessage = @"Password is incorect")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }
        public int Phone { get; set; }
        //UserType
        public string? UserType { get; set; }
        //Organization
        public Guid OrganizationId { get; set; }
        public string? Title { get; set; }
        public string? LegalName { get; set; }


        public string? IncorrectInput { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
