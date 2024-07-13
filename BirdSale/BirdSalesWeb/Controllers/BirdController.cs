using Microsoft.AspNetCore.Mvc;

namespace BirdSalesWeb.Controllers
{
    public class BirdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult AddBird()
        {
            return View();
        }
    }
}
