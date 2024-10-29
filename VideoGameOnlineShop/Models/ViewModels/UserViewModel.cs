using VideoGameOnlineShopDomain.DomainModels.Common;

namespace VideoGameOnlineShopApplication.Models.ViewModels
{
    public class UserViewModel : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}
