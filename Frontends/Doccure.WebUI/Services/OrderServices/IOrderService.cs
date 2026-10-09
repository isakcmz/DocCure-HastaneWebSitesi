using Doccure.WebUI.Dtos.OrderDtos;

namespace Doccure.WebUI.Services.OrderServices
{
    public interface IOrderService
    {
        Task<List<ResultOrderDto>> GetAllOrderAsync();
        Task<GetOrderByIdDto> GetOrderByIdAsync(int id);
    }
}
