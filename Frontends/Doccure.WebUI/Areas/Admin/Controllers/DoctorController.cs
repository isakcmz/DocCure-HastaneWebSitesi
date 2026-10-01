using Doccure.WebUI.Dtos.DoctorDtos;
using Doccure.WebUI.Services.DoctorServices;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }



        public async Task<IActionResult> DoctorList()
        {
            try
            {
                var values = await _doctorService.GetAllDoctorsAsync();
                return View(values);
            }
            catch (UnauthorizedAccessException ex)
            {
                if (ex.Message == "403")
                {
                    return RedirectToAction("Forbidden403", "Error", new { area = "" });
                }

                return RedirectToAction("SignIn", "Login");
            }
        }



        [HttpGet]
        public IActionResult CreateDoctor()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto createDoctorDto)
        {
            await _doctorService.CreateDoctorAsync(createDoctorDto);
            return RedirectToAction("DoctorList");
        }





        public async Task<IActionResult> DeleteDoctor(string id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction("DoctorList");
        }






        [HttpGet]
        public async Task<IActionResult> UpdateDoctor(string id)
        {
            var value = await _doctorService.GetDoctorByIdAsync(id);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorDto updateDoctorDto)
        {
            await _doctorService.UpdateDoctorAsync(updateDoctorDto);
            return RedirectToAction("DoctorList");
        }
    }
}
