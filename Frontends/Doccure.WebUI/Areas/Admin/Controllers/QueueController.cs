using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QueueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
