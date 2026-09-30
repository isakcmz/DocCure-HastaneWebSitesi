using Doccure.WebUI.Dtos.BranchDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
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
            PrepareAuthorizationHeader();

            var jsonData = JsonConvert.SerializeObject(createBranchDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:5000/api/Branches", stringContent);

            await HandleResponseError(responseMessage);

        }

        public async Task DeleteBranchAsync(string id)
        {
            PrepareAuthorizationHeader();
            var responseMessage = await _httpClient.DeleteAsync($"https://localhost:5000/api/Branches?id={id}");
            await HandleResponseError(responseMessage);
        }


        public async Task<List<ResultBranchDto>> GetAllBranchAsync()
        {
            PrepareAuthorizationHeader();

            // Gateway üzerinden isteği gönder
            var responseMessage = await _httpClient.GetAsync("https://localhost:5000/api/Branches");

            await HandleResponseError(responseMessage);

            // Gelen JSON veriyi oku
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            
            // DTO listesine çevir
            var values = JsonConvert.DeserializeObject<List<ResultBranchDto>>(jsonData);
            
            return values;
        }


        public async Task<GetBranchByIdDto> GetBranchByIdAsync(string id)
        {
            PrepareAuthorizationHeader();

            var responseMessage = await _httpClient.GetAsync($"https://localhost:5000/api/Branches/GetBranch?id={id}");

            await HandleResponseError(responseMessage);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetBranchByIdDto>(jsonData);
            
            return values;
        }



        public async Task UpdateBranchAsync(UpdateBranchDto dto)
        {
            PrepareAuthorizationHeader();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("https://localhost:5000/api/Branches", stringContent);
            await HandleResponseError(responseMessage);
        }




        private void PrepareAuthorizationHeader()
        {
            // Session içinden JWT token al
            var token = _httpContextAccessor.HttpContext.Session.GetString("JwtToken");

            token = token?.Trim().Replace("\"", "");

            // Bearer token al
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }




        public async Task HandleResponseError(HttpResponseMessage responseMessage)
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
