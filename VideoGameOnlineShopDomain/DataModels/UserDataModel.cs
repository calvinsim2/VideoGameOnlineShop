using VideoGameOnlineShopDomain.DomainModels.Common;

namespace VideoGameOnlineShopDomain.DataModels
{
    public class UserDataModel : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}
