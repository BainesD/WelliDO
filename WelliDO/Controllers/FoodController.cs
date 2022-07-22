using Microsoft.AspNetCore.Mvc;
using WelliDO.Models;

namespace WelliDO.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Options(FoodModel model)
        {
            if(ModelState.IsValid)
            {
                FoodModel.StoreUserInputs(model);
            }
            return View("Options", model);
        }
        public IActionResult Lucky(FoodModel model)
        {
            if (ModelState.IsValid)
            {
                FoodModel.StoreUserInputs(model);
            }
            return View("Lucky", model);
        }

    }
}
