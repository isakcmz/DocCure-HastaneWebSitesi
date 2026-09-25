using Doccure.DoctorService.Dtos.DoctorDtos;

namespace Doccure.DoctorService.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        public Task CreateAsync(CreateDoctorDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultDoctorDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetDoctorByIdDto> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateDoctorDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
