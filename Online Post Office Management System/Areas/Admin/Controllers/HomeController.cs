using Microsoft.AspNetCore.Mvc;

namespace Online_Post_Office_Management_System.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Customer()
        {
            return View();
        }
        public IActionResult Deliverd()
        {
            return View();
        }
    }
}
