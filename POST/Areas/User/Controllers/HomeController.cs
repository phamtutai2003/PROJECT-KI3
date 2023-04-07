using Microsoft.AspNetCore.Mvc;

namespace POST.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Pricing_Plan()
        {
            return View();
        }
        public IActionResult Features()
        {
            return View();
        }
        public IActionResult Free_Quote()
        {
            return View();
        }
        public IActionResult Team()
        {
            return View();
        }
        public IActionResult Testimonial()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

    }
}
