using VideoGameOnlineShopDomain.DomainModels.Common;

namespace VideoGameOnlineShopDomain.DomainModels
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}
