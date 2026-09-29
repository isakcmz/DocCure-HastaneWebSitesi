using Doccure.WebUI.Dtos.BranchDtos;
using Newtonsoft.Json;
using System.Text;

namespace Doccure.WebUI.Services.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly HttpClient _httpClient;

        public BranchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task CreateBranchAsync(CreateBranchDto createBranchDto)
        {
            var jsonData = JsonConvert.SerializeObject(createBranchDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("https://localhost:5000/api/Branches", stringContent);

            if(result.IsSuccessStatusCode)
            {

            }
        }

        public async Task DeleteBranchAsync(string id)
        {
            await _httpClient.DeleteAsync($"https://localhost:5000/api/Branches?id={id}");
        }

        public async Task<List<ResultBranchDto>> GetAllBranchAsync()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:5000/api/Branches");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBranchDto>>(jsonData);
            return values;
        }

        public Task<GetBranchByIdDto> GetBranchByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBranchAsync(UpdateBranchDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
