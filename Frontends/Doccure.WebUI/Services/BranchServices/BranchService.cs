using Doccure.WebUI.Dtos.BranchDtos;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Doccure.WebUI.Services.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BranchService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }



        public async Task CreateBranchAsync(CreateBranchDto createBranchDto)
        {
            var jsonData = JsonConvert.SerializeObject(createBranchDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("https://localhost:5000/api/Branches", stringContent);

            if(result.IsSuccessStatusCode)
            {
                //işlem
            }
        }

        public async Task DeleteBranchAsync(string id)
        {
            await _httpClient.DeleteAsync($"https://localhost:5000/api/Branches?id={id}");
        }


        public async Task<List<ResultBranchDto>> GetAllBranchAsync()
        {
            // Session içinden JWT token al
            var token = _httpContextAccessor.HttpContext.Session.GetString("JwtToken");

            token = token.Trim().Replace("\"", "");

            // Bearer token al
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Gateway üzerinden isteği gönder
            var responseMessage = await _httpClient.GetAsync("https://localhost:5000/api/Branches");
            
            // Gelen JSON veriyi oku
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            
            // DTO listesine çevir
            var values = JsonConvert.DeserializeObject<List<ResultBranchDto>>(jsonData);
            
            return values;
        }


        public async Task<GetBranchByIdDto> GetBranchByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"https://localhost:5000/api/Branches/GetBranch?id={id}");

            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetBranchByIdDto>(jsonData);
                return values;
            }

            return null;
        }



        public async Task UpdateBranchAsync(UpdateBranchDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("https://localhost:5000/api/Branches", stringContent);
        }
    }
}
