using VideoGameOnlineShopDomain.DomainModels;

namespace VideoGameOnlineShopDomain.DataModels
{
    public class RegisterUserDataModel : User
    {
        public string Password { get; set; } = string.Empty;
    }
}
