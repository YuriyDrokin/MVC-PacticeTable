using Microsoft.AspNetCore.Mvc;

namespace MVC_SellingObjectsApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
