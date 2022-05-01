using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCWebApplication.Models;
using SoftBox.DataBase.Entities;

namespace MVCWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //TODO Validation there 

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Login(string returnUrl = "/")
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index","Home");
            }
            returnUrl = returnUrl.Replace("%2F", "/");

            var model = new UserLogin
            {
                ReturnUrl = returnUrl
            };
            
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
