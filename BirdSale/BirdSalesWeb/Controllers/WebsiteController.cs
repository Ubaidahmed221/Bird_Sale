using Microsoft.AspNetCore.Mvc;

namespace BirdSalesWeb.Controllers
{
    public class WebsiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Faqus()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
    }
}
