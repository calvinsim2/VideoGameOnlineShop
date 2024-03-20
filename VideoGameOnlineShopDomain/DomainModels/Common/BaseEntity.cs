using System.ComponentModel.DataAnnotations;

namespace VideoGameOnlineShopDomain.DomainModels.Common
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeUpdated { get; set; }
    }
}
