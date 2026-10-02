using AutoMapper;
using Doccure.PatientService.Context;
using Doccure.PatientService.Dtos.AppointmentDto;
using Doccure.PatientService.Dtos.DoctorDtos;
using Doccure.PatientService.Dtos.IdentityDtos;
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
            var patients = await _context.Patients.ToListAsync();

            var result = new List<ResultPatientDto>();

            foreach (var patient in patients)
            {
                var identityUser = await _httpClient.GetFromJsonAsync<IdentityUserDto>($"https://localhost:7170/api/Users/{patient.AppUserId}");

                LastAppointmentDto? lastAppointment = null;

                var response = await _httpClient.GetAsync(
                    $"https://localhost:7018/api/Appointments/patient/{patient.AppUserId}/last");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    lastAppointment = null;
                }
                else
                {
                    response.EnsureSuccessStatusCode();

                    lastAppointment = await response.Content.ReadFromJsonAsync<LastAppointmentDto>();
                }

                DoctorSummaryDto doctor = null;

                // DOCTOR + BRANCH
                if (lastAppointment != null && !string.IsNullOrEmpty(lastAppointment.DoctorId))
                {
                    doctor = await _httpClient
                        .GetFromJsonAsync<DoctorSummaryDto>($"https://localhost:7002/api/Doctors/{lastAppointment.DoctorId}/summary");
                }

                var dto = new ResultPatientDto
                {
                    PatientId = patient.PatientId,
                    AppUserId = patient.AppUserId,
                    TcKimlikNo = patient.TcKimlikNo,
                    InsuranceType = patient.InsuranceType,
                    CreatedDate = patient.CreatedDate,
                    Status = patient.Status,

                    Name = identityUser.Name,
                    Surname = identityUser.Surname,
                    FullName = $"{identityUser.Name} {identityUser.Surname}",
                    Email = identityUser.Email,
                    PhoneNumber = identityUser.PhoneNumber,
                    Gender = identityUser.Gender,
                    BirthDate = identityUser.BirthDate,
                    BloodGroup = identityUser.BloodGroup,
                    ImageUrl = identityUser.ImageUrl,
                    City = identityUser.City,
                    Address = identityUser.Address,

                    // APPOINTMENT
                    LastVisitDate = lastAppointment?.AppointmentDate,
                    CurrentDiagnosis = lastAppointment?.Diagnosis,

                    // DOCTOR
                    DoctorId = doctor?.DoctorId,
                    DoctorName = doctor != null
                        ? $"{doctor.Name} {doctor.Surname}"
                        : null,

                    // BRANCH
                    BranchId = doctor?.BranchId,
                    BranchName = doctor?.BranchName

                };

                result.Add(dto);
            }

            return result;
        }
    }
}
