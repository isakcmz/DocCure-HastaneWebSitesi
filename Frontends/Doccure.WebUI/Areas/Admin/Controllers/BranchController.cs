using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    public class BranchController : Controller
    {
        [Area("Admin")]
        public IActionResult BranchList()
        {
            return View();
        }
    }
}
