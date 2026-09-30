using Doccure.WebUI.Dtos.DoctorDtos;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Doccure.WebUI.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }



        public async Task CreateDoctorAsync(CreateDoctorDto createDoctorDto)
        {
            PrepareAuthorizationHeader();

            var jsonData = JsonConvert.SerializeObject(createDoctorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:5000/api/Doctors", stringContent);
            
            await HandleResponseErrors(responseMessage);
        }


        public async Task DeleteDoctorAsync(string id)
        {
            PrepareAuthorizationHeader();

            var responseMessage = await _httpClient.DeleteAsync($"https://localhost:5000/api/Doctors?id={id}");

            await HandleResponseErrors(responseMessage);
        }


        public async Task<List<ResultDoctorDto>> GetAllDoctorsAsync()
        {
            PrepareAuthorizationHeader();

            var responseMessage = await _httpClient.GetAsync("https://localhost:5000/api/Doctors");

            await HandleResponseErrors(responseMessage);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDoctorDto>>(jsonData);

            return values;
        }


        public async Task<GetDoctorByIdDto> GetDoctorByIdAsync(string id)
        {
            PrepareAuthorizationHeader();

            var responseMessage = await _httpClient.GetAsync($"https://localhost:5000/api/Doctors/{id}");

            await HandleResponseErrors(responseMessage);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetDoctorByIdDto>(jsonData);

            return value;
        }


        public async Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto)
        {
            PrepareAuthorizationHeader();

            var jsonData = JsonConvert.SerializeObject(updateDoctorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("https://localhost:5000/api/Doctors", stringContent);

            await HandleResponseErrors(responseMessage);
        }







        private void PrepareAuthorizationHeader()
        {
            // Session içinden JWT token al
            var token = _httpContextAccessor.HttpContext.Session.GetString("JwtToken");

            token = token?.Trim().Replace("\"", "");

            // Bearer token al
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }




        public async Task HandleResponseErrors(HttpResponseMessage responseMessage)
        {

            if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException("403");
            }

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("401");
            }

            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("404");
            }

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Bir hata oluştu!");
            }

        }
    }
}
