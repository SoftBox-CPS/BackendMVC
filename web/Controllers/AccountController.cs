using Microsoft.AspNetCore.Mvc;

namespace MVCWebApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //TODO Validation there 

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        // TODO Login & View
    }
}
