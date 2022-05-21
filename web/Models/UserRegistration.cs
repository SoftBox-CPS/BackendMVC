using System.ComponentModel.DataAnnotations;

namespace MVCWebApplication.Models;

public class UserRegistration
{
    [Required]
    public string Login { get; set; }

    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string? Patronymic { get; set; }

    [Required]
    [MaxLength(20)]
    [Phone]
    public string Phone { get; set; }
    [Required]
    [MaxLength(254)]
    [EmailAddress]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

}
