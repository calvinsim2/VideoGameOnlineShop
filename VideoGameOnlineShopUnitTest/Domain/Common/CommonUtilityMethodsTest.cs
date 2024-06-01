using VideoGameOnlineShopDomain.Common;
using VideoGameOnlineShopDomain.Common.Exceptions;

namespace VideoGameOnlineShopUnitTest.Domain.Common
{
    public class CommonUtilityMethodsTest
    {
        public readonly CommonUtilityMethods _commonUtilityMethodsMock = new CommonUtilityMethods();


        #region ValidateStringIfConvertableToGuid
        [Fact]
        public void ValidateStringIfConvertableToGuid_Positive_StringIsConvertible_ReturnGuid()
        {
            // Arrange
            string mockGuidString = "acd77fe2-aee4-4161-9e0d-dab702b4b0c9";

            // Act
            Guid results = _commonUtilityMethodsMock.ConvertStringToGuid(mockGuidString);

            // Assert
            Assert.Equal(Guid.Parse(mockGuidString), results);
        }

        [Fact]
        public void ValidateStringIfConvertableToGuid_Negative_StringIsNotConvertible_ThrowException()
        {
            // Arrange
            string mockGuidString = "Not a GUID";

            // Act

            // Assert
            Assert.Throws<BadRequestException>(() => _commonUtilityMethodsMock.ConvertStringToGuid(mockGuidString));
        }

        #endregion

        #region ValidateStringIfIsEmptyOrNull

        [Fact]
        public void ValidateStringIfIsEmptyOrNull_Positive_StringIsEmptyOrNull_ThrowException()
        {
            // Arrange
            string mockGuidString = string.Empty;

            // Act

            // Assert
            Assert.Throws<BadRequestException>(() => _commonUtilityMethodsMock.ValidateStringIfIsEmptyOrNull(mockGuidString));
        }

        [Fact]
        public void ValidateStringIfIsEmptyOrNull_Negative_StringIsNotEmptyOrNull_NoActionTaken()
        {
            // Arrange
            string mockGuidString = "random string";

            // Act

            _commonUtilityMethodsMock.ValidateStringIfIsEmptyOrNull(mockGuidString);

            // Assert
            Assert.NotEmpty(mockGuidString);
        }

        #endregion

        #region RemoveEmptySpaceAndCapitalizeString

        [Fact]
        public void RemoveEmptySpaceAndCapitalizeString_Positive_RandomStringProvided_ReturnMutatedString()
        {
            // Arrange
            string mockString = "abc d";
            string expectedString = "ABCD";

            // Act

            string result = _commonUtilityMethodsMock.RemoveEmptySpaceAndCapitalizeString(mockString);

            // Assert
            Assert.Equal(expectedString, result);
        }

        #endregion

        #region ConvertStringsToListRemoveNullAndEmptyElements

        [Fact]
        public void ConvertStringsToListRemoveNullAndEmptyElements_Positive_RandomStringProvided_ReturnList()
        {
            // Arrange
            string mockString = "1,2,3,4";

            // Act

            var result = _commonUtilityMethodsMock.ConvertStringsToListRemoveNullAndEmptyElements(mockString);

            // Assert
            Assert.NotEmpty(result);
        }

        #endregion
    }
}
