using Doccure.MarketService.Dtos.CartDtos;

namespace Doccure.MarketService.Services.CartServices
{
    public interface ICartService
    {
        Task<List<CartItemDto>> GetCartAsync(int patientId);
        Task AddItemToCartAsync(int patientId, CartItemDto cartItemDto);
        Task RemoveItemAsync(int patientId, int productId);
        Task ClearCartAsync(int patientId);
    }
}
