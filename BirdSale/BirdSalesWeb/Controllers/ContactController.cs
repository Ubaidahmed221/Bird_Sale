using Microsoft.AspNetCore.Mvc;

namespace BirdSalesWeb.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
