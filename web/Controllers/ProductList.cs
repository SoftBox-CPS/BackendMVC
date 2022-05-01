using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCWebApplication.Data;
using SoftBox.DataBase.Entities;

namespace MVCWebApplication.Controllers
{
    [Authorize]
    public class ProductList : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductList(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objProductsList = _db.Products.ToList();
            return View(objProductsList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }
        //Post Create Category with validation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customer", "The Display cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category create successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categoryFromDb = _db.Products.Find(id);

            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }
        //Post Edit Products with validation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product objProducts)
        {
            if (objProducts.Name == objProducts.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Customer", "The Display cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Products.Update(objProducts);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(objProducts);
        }
        //Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var categoryFromDb = _db.Products.Find(id);
            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }

        //Post Delete Products with validation
        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Products.Find(id);
            if (obj == null)
                return NotFound();

            _db.Products.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
