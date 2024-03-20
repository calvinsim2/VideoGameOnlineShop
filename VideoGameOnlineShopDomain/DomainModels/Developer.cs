using VideoGameOnlineShopDomain.DomainModels.Common;

namespace VideoGameOnlineShopDomain.DomainModels
{
    public class Developer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Slogan { get; set; } = string.Empty;
        public string Logo {  get; set; } = string.Empty;
    }
}
