using Microsoft.AspNetCore.Mvc;
using WelliDO.Clients;

namespace WelliDO.Controllers
{
    public class PickerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Food()
        { 
            return View();
        }
    }
}
