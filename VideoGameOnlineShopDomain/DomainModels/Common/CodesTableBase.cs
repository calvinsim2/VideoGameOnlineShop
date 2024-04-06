using VideoGameOnlineShopDomain.Interfaces.CodesTable;

namespace VideoGameOnlineShopDomain.DomainModels.Common
{
    public abstract class CodesTableBase : ICodesTableBase
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string DecodeValue { get; set; } = string.Empty;

        public CodesTableBase() { }

        public CodesTableBase(string code, string decodeValue) : base()
        {
            Code = code;
            DecodeValue = decodeValue;
        } 
    }
}
