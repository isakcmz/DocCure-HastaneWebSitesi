using Doccure.AppointmentService.Dtos.AppointmentDtos;
using Doccure.AppointmentService.Services.AppointmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doccure.AppointmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAppointment()
        {
            var values = await _appointmentService.GetAllAsync();
            return Ok(values);
        }


        [HttpGet("GetAppointment")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var value = await _appointmentService.GetByIdAsync(id);

            if (value == null)
                return NotFound("Randevu bulunamadı.");
            
            return Ok(value);
        }



        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentDto dto)
        {
            await _appointmentService.CreateAsync(dto);
            return Ok("Randevu başarıyla oluşturuldu.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentDto dto)
        {
            await _appointmentService.UpdateAsync(dto);
            return Ok("Randevu başarıyla güncellendi.");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAsync(id);
            return Ok("Randevu başarıyla silindi");
        }
    }
}
