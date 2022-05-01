using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCWebApplication.Models
{
    public class UserLogin
    {
        [Required]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
