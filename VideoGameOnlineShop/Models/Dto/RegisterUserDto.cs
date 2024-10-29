using VideoGameOnlineShopDomain.DomainModels;

namespace VideoGameOnlineShopApplication.Models.Dto
{
    public class RegisterUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
    }
}
