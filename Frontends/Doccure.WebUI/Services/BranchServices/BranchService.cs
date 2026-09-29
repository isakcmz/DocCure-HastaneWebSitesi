using Doccure.WebUI.Dtos.BranchDtos;
using Newtonsoft.Json;

namespace Doccure.WebUI.Services.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly HttpClient _httpClient;

        public BranchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public Task CreateBranchAsync(CreateBranchDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBranchAsync(string id)
        {
            throw new NotImplementedException();
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
