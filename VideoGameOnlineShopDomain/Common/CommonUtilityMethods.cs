using VideoGameOnlineShopDomain.Common.Exceptions;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopDomain.Common
{
    public class CommonUtilityMethods : ICommonUtilityMethods
    {
        public CommonUtilityMethods() { }

        public Guid ConvertStringToGuid(string stringId)
        {
            bool isIdParsable = Guid.TryParse(stringId, out Guid guidId);

            if (!isIdParsable)
            {
                throw new BadRequestException("Please input correct Guid format");
            }

            return guidId;
        }

        public void ValidateStringIfIsEmptyOrNull(string inputString)
        {
            string inputStringRemoveEmptySpace = inputString.Replace(" ", string.Empty);

            if (string.IsNullOrEmpty(inputStringRemoveEmptySpace))
            {
                throw new BadRequestException("Input String cannot be empty");
            }
        }

        public string RemoveEmptySpaceAndCapitalizeString(string inputString)
        {
            string inputStringRemoveEmptySpace = inputString.Replace(" ", string.Empty);

            return inputStringRemoveEmptySpace.ToUpper();
        }

        public IEnumerable<string> ConvertStringsToListRemoveNullAndEmptyElements(string inputString)
        {
            List<string> stringList = inputString.Split(",").ToList();

            stringList.RemoveAll(s => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s));

            return stringList;
        }
    }
}
