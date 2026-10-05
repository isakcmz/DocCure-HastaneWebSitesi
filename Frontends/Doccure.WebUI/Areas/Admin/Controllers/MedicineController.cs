using Doccure.WebUI.Services.MedicineServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicineController : Controller
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }




        public async Task<IActionResult> MedicineList()
        {
            var values = await _medicineService.GetAllMedicinesAsync();
            return View(values);
        }
    }
}
