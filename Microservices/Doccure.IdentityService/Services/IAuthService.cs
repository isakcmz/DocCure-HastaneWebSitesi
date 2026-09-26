using Doccure.IdentityService.Dtos;

namespace Doccure.IdentityService.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
    }
}
