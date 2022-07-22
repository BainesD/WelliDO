using Microsoft.AspNetCore.Mvc;
using WelliDO.Models;

namespace WelliDO.Controllers
{
    public class DrinkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DrinkOptions(DrinkModel model)
        {
            if (ModelState.IsValid)
            {
                DrinkModel.StoreUserInputs(model);
            }
            return View("DrinkOptions", model);
        }
        public IActionResult DrinkLucky(DrinkModel model)
        {
            if(ModelState.IsValid)
            {
                DrinkModel.StoreUserInputs(model);
            }
            return View("DrinkLucky", model);
        }

    }
}
