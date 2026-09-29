using Doccure.WebUI.Dtos.LoginDtos;
using Newtonsoft.Json;
using System.Text;

namespace Doccure.WebUI.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var jsonData = JsonConvert.SerializeObject(loginDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:5000/api/auth/login", stringContent);

            if(!responseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            var token = await responseMessage.Content.ReadAsStringAsync();
            return token;
        }
    }
}
