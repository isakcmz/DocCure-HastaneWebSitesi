using Doccure.WebUI.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        public async Task<IActionResult> SihnUp(RegisterViewModel model)
        {
            return View();
        }
    }
}
