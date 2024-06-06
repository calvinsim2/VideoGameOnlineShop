using FakeItEasy;
using VideoGameOnlineShopDomain.Interfaces;
using VideoGameOnlineShopDomain.Services;

namespace VideoGameOnlineShopUnitTest.Domain.Services
{
    public class DeveloperServiceUnitTest
    {
        public static readonly IGameRepository _gameRepositoryMock = A.Fake<IGameRepository>();
        public static readonly IDeveloperRepository _developerRepositoryMock = A.Fake<IDeveloperRepository>();
        public static readonly IGameService _gameServiceMock = A.Fake<IGameService>();
        public readonly DeveloperService developerService = new DeveloperService(_gameRepositoryMock, 
                                                                                 _developerRepositoryMock,
                                                                                 _gameServiceMock);

        [Fact]
        public async Task GetAllExistingDevelopersAsync_Positive_ExistingDevelopersFound_ReturnListOfDevelopers()
        {
            // Arrange
            VideoGameOnlineShopDomain.DomainModels.Developer developerMock = new VideoGameOnlineShopDomain.DomainModels.Developer();

            List<VideoGameOnlineShopDomain.DomainModels.Developer> developersMock = 
                new List<VideoGameOnlineShopDomain.DomainModels.Developer>
            {
                developerMock
            };

            // Act
            A.CallTo(() => _developerRepositoryMock.GetAllDevelopersAsync(A<bool>.Ignored))
                                .WithAnyArguments().Returns(developersMock);


            var result = await developerService.GetAllExistingDevelopersAsync();

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public async Task GetAllExistingDevelopersAsync_Negative_NoDevelopersFound_ReturnEmptyList()
        {
            // Arrange

            List<VideoGameOnlineShopDomain.DomainModels.Developer> developersMock = 
                new List<VideoGameOnlineShopDomain.DomainModels.Developer>();

            // Act
            A.CallTo(() => _developerRepositoryMock.GetAllDevelopersAsync(A<bool>.Ignored))
                           .WithAnyArguments().Returns(developersMock);


            var result = await developerService.GetAllExistingDevelopersAsync();

            // Assert
            Assert.Empty(result);
        }
    }
}
