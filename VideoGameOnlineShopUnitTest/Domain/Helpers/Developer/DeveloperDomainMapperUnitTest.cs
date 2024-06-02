using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.Helpers.Developer;

namespace VideoGameOnlineShopUnitTest.Domain.Helpers.Developer
{
    public class DeveloperDomainMapperUnitTest
    {
        [Fact]
        public void MapDeveloperDataModelToDeveloper_Positive_DeveloperDataModelApplied_ReturnDeveloper()
        {
            // Arrange
            DeveloperDataModel developerMock = new DeveloperDataModel
            {
                Name = "Test",
                Logo = "TestLogo",
                Slogan = "TestSlogan",
            };

            // Act
            var result = DeveloperDomainMapper.MapDeveloperDataModelToDeveloper(developerMock);

            // Assert
            Assert.IsType<VideoGameOnlineShopDomain.DomainModels.Developer>(result);
            Assert.Equal(developerMock.Name, result.Name);
            Assert.Equal(developerMock.Logo, result.Logo);
            Assert.Equal(developerMock.Slogan, result.Slogan);
        }

        [Fact]
        public void MapDeveloperToDeveloperDataModel_Positive_DeveloperModelApplied_ReturnDeveloperDataModel()
        {
            // Arrange
            VideoGameOnlineShopDomain.DomainModels.Developer developerDataModelMock = new VideoGameOnlineShopDomain.DomainModels.Developer
            {
                Name = "Test",
                Logo = "TestLogo",
                Slogan = "TestSlogan",
            };

            // Act
            var result = DeveloperDomainMapper.MapDeveloperToDeveloperDataModel(developerDataModelMock);

            // Assert
            Assert.IsType<DeveloperDataModel>(result);
            Assert.Equal(developerDataModelMock.Name, result.Name);
            Assert.Equal(developerDataModelMock.Logo, result.Logo);
            Assert.Equal(developerDataModelMock.Slogan, result.Slogan);
        }
    }
}
