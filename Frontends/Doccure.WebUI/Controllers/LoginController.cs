using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
