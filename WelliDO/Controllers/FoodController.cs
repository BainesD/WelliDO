using Microsoft.AspNetCore.Mvc;

namespace WelliDO.Controllers
{
    public class FoodController : PickerController
    {
        public IActionResult Options()
        {
            return View();
        }
    }
}
