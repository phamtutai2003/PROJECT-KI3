using Microsoft.AspNetCore.Mvc;

namespace Project3.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area ("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
