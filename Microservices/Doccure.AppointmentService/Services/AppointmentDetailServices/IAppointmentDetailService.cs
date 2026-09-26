using Doccure.AppointmentService.Dtos.AppointmentDetailDtos;

namespace Doccure.AppointmentService.Services.AppointmentDetailServices
{
    public interface IAppointmentDetailService
    {
        Task CreateAsync(CreateAppointmentDetailDto dto);
        Task<ResultAppointmentDetailDto> GetAppointmentByIdAsync(int appointmentId);
        Task UpdateAsync(UpdateAppointmentDetailDto dto);

    }
}
