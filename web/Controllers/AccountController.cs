using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCWebApplication.Models;
using SoftBox.DataBase.Entities;
using SoftBox.DataBase.InterfacesRepository;
using System.Security.Claims;

namespace MVCWebApplication.Controllers;

public class AccountController : Base.ViewController
{
    private readonly IUserRepository userRepository;

    public AccountController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }


    [HttpGet]
    [AllowAnonymous]
    public IActionResult Registration()
    {
        return View();
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Registration(UserRegistration userRegistration)
    {
        if (!ModelState.IsValid)
        {
            return View(BadRequest, modelState: ModelState);
        }

        if (await userRepository.IsLoginExist(userRegistration.Login))
        {
            ModelState.AddModelError("Login", "Уже существует.");
            return View(BadRequest, modelState: ModelState);
        }

        var user = await userRepository.Add(new User()
        {
            FirstName = userRegistration.FirstName,
            LastName = userRegistration.LastName,
            Email = userRegistration.Email,
            Login = userRegistration.Login,
            Patronymic = userRegistration.Patronymic,
            Phone = userRegistration.Phone,
            UserTypeId = 1,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRegistration.Password)
        });

        if (String.IsNullOrEmpty(user.Id.ToString())
            || !await Authenticate(new UserLogin()
            {
                Login = userRegistration.Login,
                Password = userRegistration.Password
            }
            ))
        {
            ModelState.AddModelError("Login", "Произошла непридвиденная ошибка. Повторите запрос позднее");
            //Replace on 500
            return View(BadRequest, modelState: ModelState);
        }
        if (!IsView())
        {
            return Ok("ok");
        }

        return RedirectToAction("Index", "Home");

    }
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {

        return View();
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(UserLogin userLogin, string? returnUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(Unauthorized, modelState: ModelState);
        }

        if (!await Authenticate(userLogin))
        {
            ModelState.AddModelError("Login", "Некорректные логин и(или) пароль");
            return this.View(Unauthorized, modelState: ModelState);

        }

        if (!IsView())
        {
            return Ok("ok");
        }

        if (String.IsNullOrEmpty(returnUrl))
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return Redirect(returnUrl);
        }

    }


    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

    private async Task<bool> Authenticate(UserLogin userLogin)
    {
        var user = await userRepository.GetUserByLogin(userLogin.Login);
        if (user == null
            || !BCrypt.Net.BCrypt.Verify(userLogin.Password, user.PasswordHash))
        {
            return false;
        }
        var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserType?.Name)
            };

        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        return true;
    }
}