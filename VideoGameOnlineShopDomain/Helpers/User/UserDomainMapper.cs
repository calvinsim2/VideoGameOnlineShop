using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopDomain.Helpers.User
{
    public class UserDomainMapper
    {
        public static DomainModels.User MapRegisterUserDataModelToUser(RegisterUserDataModel registerUserDataModel)
        {
            DomainModels.User user = new DomainModels.User
            {
                Username = registerUserDataModel.Username,
                DisplayName = registerUserDataModel.DisplayName,
                DateTimeCreated = registerUserDataModel.DateTimeCreated,
                DateTimeUpdated = registerUserDataModel.DateTimeUpdated,
            };

            return user;

        }

        public static UserDataModel MapUserToUserDataModel(DomainModels.User user)
        {
            UserDataModel userDataModel = new UserDataModel 
            {
                Id = user.Id,
                Username = user.Username,
                DisplayName = user.DisplayName,
                DateTimeCreated = user.DateTimeCreated,
                DateTimeUpdated = user.DateTimeUpdated,
                IsAdmin = user.IsAdmin,
            };

            return userDataModel;

        }
    }
}
