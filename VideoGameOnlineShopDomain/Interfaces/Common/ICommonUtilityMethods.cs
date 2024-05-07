namespace VideoGameOnlineShopDomain.Interfaces.Common
{
    public interface ICommonUtilityMethods
    {
        Guid ValidateStringIfConvertableToGuid(string stringId);
        string RemoveEmptySpaceAndCapitalizeString(string inputString);
        void ValidateStringIfIsEmptyOrNull(string inputString);
    }
}
