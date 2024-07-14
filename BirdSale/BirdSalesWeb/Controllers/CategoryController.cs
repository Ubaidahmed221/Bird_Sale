using Microsoft.AspNetCore.Mvc;

namespace BirdSalesWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
