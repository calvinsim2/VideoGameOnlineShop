namespace VideoGameOnlineShopApplication.Models.ViewModels
{
    public class AuthViewModel
    {
        public string Token { get; set; } = string.Empty;
        public UserViewModel UserViewModel { get; set; }
    }
}
