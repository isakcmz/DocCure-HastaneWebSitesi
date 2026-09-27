using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    public class DoctorController : Controller
    {
        [Area("Admin")]
        public IActionResult DoctorList()
        {
            return View();
        }
    }
}
