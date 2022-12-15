using Microsoft.AspNetCore.Mvc;

namespace fabset_project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
    }
}
