using System.Security.Cryptography;
using VideoGameOnlineShopApplication.Helpers.User;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.Interfaces;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopApplication.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IAuthorizationUtilityMethods _authorizationUtilityMethods;
        private readonly IUserService _userService;
        public UserApplicationService(IAuthorizationUtilityMethods authorizationUtilityMethods, 
                                      IUserService userService) 
        {
            _authorizationUtilityMethods = authorizationUtilityMethods;
            _userService = userService;
        }

        public async Task RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            RegisterUserDataModel registerUserDataModel = 
                UserApplicationMapper.MapRegisterUserDtoToRegisterUserDataModel(registerUserDto);

            await _userService.RegisterUserAsync(registerUserDataModel);
        }

        public async Task<AuthViewModel> LoginUserAsync(LoginDto loginDto)
        {
            LoginRequestDataModel loginRequestDataModel =
                UserApplicationMapper.MapLoginDtoToLoginDataModel(loginDto);

            AuthViewModel authViewModel = new AuthViewModel();

            UserDataModel userDataModel = await _userService.LoginUserAsync(loginRequestDataModel);
            authViewModel.UserViewModel = UserApplicationMapper.MapUserDataModelToUserViewModel(userDataModel);

            authViewModel.Token = _authorizationUtilityMethods.CreateToken(userDataModel);

            return authViewModel;

        }
    }
}
