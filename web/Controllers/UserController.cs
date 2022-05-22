using Microsoft.AspNetCore.Mvc;
using SoftBox.DataBase.InterfacesRepository;

namespace MVCWebApplication.Controllers
{
    public class UserController : Base.EntityController<SoftBox.DataBase.Entities.User, Guid>
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository): base(userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IActionResult> Index(Guid userId)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            return View(user);
        }

        public IActionResult UserProfile()
        {
            return View();
        }
    }
}
