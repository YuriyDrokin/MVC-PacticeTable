using Microsoft.AspNetCore.Mvc;
using MVC_SellingObjectsApp.Data;
using MVC_SellingObjectsApp.Models;

namespace MVC_SellingObjectsApp.Controllers
{
    public class CategoryController : Controller
    {
        //access database object
        private readonly ApplicationDbContext _db;

        // using constructoir whatever register inside the container we can get implementation of the connection and retrieve the Data
         public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories; // accessing to db set and converting to a list and store in ObjCategoryList, no need sql statements 
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] // cross site request forgery and AntoForgery token
        public IActionResult Create(Category obj)
        {
            // Validation for entering same name and Validorder value
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot MATCH the Name");
            }

            if(ModelState.IsValid) { // check validation
            _db.Categories.Add(obj); // creating record in database just addin into database
            _db.SaveChanges();// that will push into database when we save all the changes
            return RedirectToAction("Index"); // redirecto to index page to what happened 
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if(categoryFromDb == null) {
            return NotFound();
            }

            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] // cross site request forgery and AntoForgery token
        public IActionResult Edit(Category obj)
        {
            // Validation for entering same name and Validorder value
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot MATCH the Name");
            }

            if (ModelState.IsValid)
            { // check validation
                _db.Categories.Update(obj); // update record in database just updates into database
                _db.SaveChanges();// that will push into database when we save all the changes
                return RedirectToAction("Index"); // redirecto to index page to what happened 
            }
            return View(obj);
        }
        // Delete
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // cross site request forgery and AntoForgery token
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if(obj == null) {
            return NotFound();
            }
            
                _db.Categories.Remove(obj); // update record in database just updates into database
                _db.SaveChanges();// that will push into database when we save all the changes
                return RedirectToAction("Index"); // redirecto to index page to what happened 
            
           
        }
    }
}
