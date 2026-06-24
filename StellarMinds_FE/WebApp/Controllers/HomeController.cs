using Microsoft.AspNetCore.Mvc;

namespace StellarMinds.AppWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
