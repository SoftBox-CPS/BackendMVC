using Microsoft.AspNetCore.Mvc;
using MVCWebApplication.Models;
using SoftBox.DataBase.Entities;
using SoftBox.DataBase.InterfacesRepository;

namespace MVCWebApplication.Controllers;

public class AccountController : Controller
{
    private readonly IUserRepository userRepository;

    public AccountController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    public IActionResult Index()
    {
        return View();
    }


    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Registration(UserRegistration user, string? returnUrl)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        if (await userRepository.IsLoginExist(user.Login))
        {
            ModelState.AddModelError("Login", "Уже существует.");
            return View();
        }
        await userRepository.Add(new User()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Login = user.Login,
            Patronymic = user.Patronymic,
            Phone = user.Phone,
            UserTypeId = 1,
            PasswordHash = BCrypt.Net.BCrypt.HashString(user.Password)
        });
        if (String.IsNullOrEmpty(returnUrl))
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return Redirect(returnUrl);
        }
    }
    [HttpGet]
    public IActionResult Login()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Login(User user, string returnUrl)
    {

        return Ok(user);
    }

    public IActionResult AccessDenied()
    {
        return View();
    }


}
