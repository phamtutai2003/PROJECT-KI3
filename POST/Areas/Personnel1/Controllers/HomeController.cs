using Microsoft.AspNetCore.Mvc;

namespace POST.Areas.Personnel.Controllers
{
    [Area ("Personnel1")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Deliverd()
        {
            return View();
        }

    }
}
