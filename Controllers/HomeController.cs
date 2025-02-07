using Microsoft.AspNetCore.Mvc;

namespace rootBooks.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}