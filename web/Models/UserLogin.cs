using System.ComponentModel.DataAnnotations;

namespace MVCWebApplication.Models;

public class UserLogin
{

    [Required]
    public string Login { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

}
