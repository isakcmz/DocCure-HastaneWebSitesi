using Doccure.WebUI.Services.BranchServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<IActionResult> BranchList()
        {
            var values = await _branchService.GetAllBranchAsync();
            return View(values);
        }
    }
}
