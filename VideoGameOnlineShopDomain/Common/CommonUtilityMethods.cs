using System.Net;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopDomain.Common
{
    public class CommonUtilityMethods : ICommonUtilityMethods
    {
        public CommonUtilityMethods() { }

        public Guid ValidateStringIfConvertableToGuid(string stringId)
        {
            bool isIdParsable = Guid.TryParse(stringId, out Guid guidId);

            if (!isIdParsable)
            {
                throw new HttpRequestException("Please input correct Guid format", null, HttpStatusCode.BadRequest);
            }

            return guidId;
        }
    }
}
