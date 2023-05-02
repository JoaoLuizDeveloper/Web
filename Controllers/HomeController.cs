using Microsoft.AspNetCore.Mvc;

namespace Web
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}