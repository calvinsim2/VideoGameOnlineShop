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

        public string RemoveEmptySpaceAndCapitalizeString(string inputString)
        {
            string inputStringRemoveEmptySpace = inputString.Replace(" ", string.Empty);

            if (string.IsNullOrEmpty(inputStringRemoveEmptySpace))
            {
                throw new HttpRequestException("Code cannot be empty", null, HttpStatusCode.BadRequest);
            }

            return inputStringRemoveEmptySpace.ToUpper();
        }

        public static IEnumerable<string> ConvertStringsToListRemoveNullAndEmptyElements(string inputString)
        {
            List<string> stringList = inputString.Split(",").ToList();

            stringList.RemoveAll(s => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s));

            return stringList;
        }
    }
}
