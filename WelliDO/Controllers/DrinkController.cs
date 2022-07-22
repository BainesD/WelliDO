using Microsoft.AspNetCore.Mvc;

namespace WelliDO.Controllers
{
    public class DrinkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
