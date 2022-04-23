using Microsoft.AspNetCore.Mvc;

namespace MVCWebApplication.Controllers
{
    public class ProductList : Controller
    {
        /*private readonly */
        public IActionResult Index()
        {
            return View();
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }
        //TODO: Post
        /*public IActionResult Create()
        {
            return View();
        }*/
    }
}
