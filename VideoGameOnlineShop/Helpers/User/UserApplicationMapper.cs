using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.DomainModels;

namespace VideoGameOnlineShopApplication.Helpers.User
{
    public class UserApplicationMapper
    {
        public static RegisterUserDataModel MapRegisterUserDtoToRegisterUserDataModel(RegisterUserDto registerUserDto)
        {
            RegisterUserDataModel registerUserDataModel = new RegisterUserDataModel
            {
                Username = registerUserDto.Username,
                Password = registerUserDto.Password,
                DisplayName = registerUserDto.DisplayName,
                DateTimeCreated = DateTime.Now,
                DateTimeUpdated = DateTime.Now,

            };

            return registerUserDataModel;
        }

        public static LoginRequestDataModel MapLoginDtoToLoginDataModel(LoginDto loginDto)
        {
            LoginRequestDataModel loginDataModel = new LoginRequestDataModel
            {
                Username = loginDto.Username,
                Password = loginDto.Password,

            };

            return loginDataModel;
        }

        public static UserViewModel MapUserDataModelToUserViewModel(UserDataModel userDataModel)
        {
            UserViewModel userViewModel = new UserViewModel
            {
                Id = userDataModel.Id,
                Username = userDataModel.Username,
                DisplayName = userDataModel.DisplayName,
                DateTimeCreated = userDataModel.DateTimeCreated,
                DateTimeUpdated = userDataModel.DateTimeUpdated,
                IsAdmin = userDataModel.IsAdmin,
            };

            return userViewModel;
        }
    }
}
