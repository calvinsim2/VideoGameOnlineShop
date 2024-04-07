using System.ComponentModel.DataAnnotations;

namespace VideoGameOnlineShopDomain.Interfaces.CodesTable
{
    public interface ICodesTableBase
    {
        public Guid Id { get; }
        public string Code { get; } 
        public string DecodeValue { get; } 
    }
}
