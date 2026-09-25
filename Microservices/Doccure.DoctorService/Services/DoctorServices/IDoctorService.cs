using Doccure.DoctorService.Dtos.DoctorDtos;

namespace Doccure.DoctorService.Services.DoctorServices
{
    public interface IDoctorService
    {
        Task<List<ResultDoctorDto>> GetAllAsync();
        Task<GetDoctorByIdDto> GetByIdAsync();
        Task CreateAsync(CreateDoctorDto dto);
        Task UpdateAsync(UpdateDoctorDto dto);
        Task DeleteAsync(string id);
    }
}
