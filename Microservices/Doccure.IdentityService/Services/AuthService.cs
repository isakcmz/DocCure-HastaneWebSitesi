using Doccure.IdentityService.Dtos;
using Doccure.IdentityService.Entities;
using Microsoft.AspNetCore.Identity;

namespace Doccure.IdentityService.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthService(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var user = new AppUser()
            {
                UserName = dto.Username,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                City = dto.City
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            return result.Succeeded;
        }




    }
}
