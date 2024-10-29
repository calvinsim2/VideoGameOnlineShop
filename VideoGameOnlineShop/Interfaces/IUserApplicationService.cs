using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;

namespace VideoGameOnlineShopApplication.Interfaces
{
    public interface IUserApplicationService
    {
        Task RegisterUserAsync(RegisterUserDto registerUserDto);
        Task<AuthViewModel> LoginUserAsync(LoginDto loginDto);
    }
}
