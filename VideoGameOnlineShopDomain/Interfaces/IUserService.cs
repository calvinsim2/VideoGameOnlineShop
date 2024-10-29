using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopDomain.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(RegisterUserDataModel registerUserDataModel);
        Task<UserDataModel> LoginUserAsync(LoginRequestDataModel loginDataModel);
    }
}
