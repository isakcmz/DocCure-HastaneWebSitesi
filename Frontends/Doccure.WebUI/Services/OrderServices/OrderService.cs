using Doccure.WebUI.Dtos.OrderDtos;
using Newtonsoft.Json;

namespace Doccure.WebUI.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }



        public async Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7215/api/Orders");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrderDto>>(jsonData);
            return values;
        }

        public async Task<GetOrderByIdDto> GetOrderByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"https://localhost:7215/api/Orders/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetOrderByIdDto>(jsonData);
            return value;
        }
    }
}
