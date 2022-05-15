using Microsoft.AspNetCore.Mvc;
using SoftBox.DataBase.InterfacesRepository;

namespace MVCWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IActionResult> Index(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return View(user);
        }

        public IActionResult UserProfile()
        {
            return View();
        }
    }
}
