namespace VideoGameOnlineShopApplication.Models.ViewModels
{
    public class CodesTableViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string DecodeValue { get; set; } = string.Empty;
    }
}
