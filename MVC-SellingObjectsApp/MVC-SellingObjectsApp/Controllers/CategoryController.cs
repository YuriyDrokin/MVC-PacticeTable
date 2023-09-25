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

        public IActionResult Create()
        {
            return View();
        }
    }
}
