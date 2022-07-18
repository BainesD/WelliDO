using Microsoft.AspNetCore.Mvc;

namespace WelliDO.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Options()
        {
            return View();
        }
    }
}
