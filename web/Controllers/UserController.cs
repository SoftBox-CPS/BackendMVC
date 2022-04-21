using Microsoft.AspNetCore.Mvc;
using SoftBox.DataBase.IntarfaceRepository;

namespace MVCWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public IActionResult Index(Guid userId)
        {
            var user = _userRepository.GetUserById(userId);
            return View(user);
        }
    }
}
