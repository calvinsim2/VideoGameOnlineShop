using VideoGameOnlineShopDomain.DomainModels;

namespace VideoGameOnlineShopApplication.Models.ViewModels
{
    public class GameApplicationViewModel : Game
    {
        public new string DeveloperId { get; set; } = string.Empty;
    }
}
