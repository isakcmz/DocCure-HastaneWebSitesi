using AutoMapper;
using Doccure.PatientService.Context;
using Doccure.PatientService.Dtos.PatientDtos;
using Microsoft.EntityFrameworkCore;

namespace Doccure.PatientService.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly PatientContext _context;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public PatientService(PatientContext context, IMapper mapper, HttpClient httpClient)
        {
            _context = context;
            _mapper = mapper;
            _httpClient = httpClient;
        }


        public async Task<List<ResultPatientDto>> GetAllPatientAsync()
        {
            var values = await _context.Patients.ToListAsync();
            return _mapper.Map<List<ResultPatientDto>>(values);
        }
    }
}
