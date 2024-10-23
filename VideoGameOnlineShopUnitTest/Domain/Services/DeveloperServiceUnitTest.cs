using FakeItEasy;
using VideoGameOnlineShopDomain.Common.Exceptions;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Interfaces;
using VideoGameOnlineShopDomain.Services;

namespace VideoGameOnlineShopUnitTest.Domain.Services
{
    public class DeveloperServiceUnitTest
    {
        public static readonly IGameRepository _gameRepositoryFake = A.Fake<IGameRepository>();
        public static readonly IDeveloperRepository _developerRepositoryFake = A.Fake<IDeveloperRepository>();
        public static readonly IGameService _gameServiceFake = A.Fake<IGameService>();
        public readonly DeveloperService _developerService = new DeveloperService(_gameRepositoryFake, 
                                                                                  _developerRepositoryFake, 
                                                                                  _gameServiceFake);

        [Fact]
        public async Task GetAllExistingDevelopersAsync_Positive_DevelopersExist_ReturnListOfDevelopers()
        {
            Developer mockDeveloper = new Developer();
            IEnumerable<Developer> developer = new List<Developer> { mockDeveloper };

            A.CallTo(() => _developerRepositoryFake.GetAllDevelopersAsync(false)).Returns(developer);

            IEnumerable<Developer> result = await _developerService.GetAllExistingDevelopersAsync();

            Assert.Single(result);
        }

        [Fact]
        public async Task GetAllExistingDevelopersAsync_Negative_NoDevelopersExist_ReturnEmptyList()
        {
            IEnumerable<Developer> developer = new List<Developer>();

            A.CallTo(() => _developerRepositoryFake.GetAllDevelopersAsync(false)).Returns(developer);

            IEnumerable<Developer> result = await _developerService.GetAllExistingDevelopersAsync();

            Assert.Empty(result);
        }

        [Fact]
        public async Task DeleteSelectedDeveloperAsync_Positive_DevelopersExist_CallDeleteMustHappen()
        {
            Guid mockGuid = Guid.NewGuid();
            Developer developer = new Developer { Id = mockGuid };

            A.CallTo(() => _developerRepositoryFake.GetByIdAsync(mockGuid, true)).WithAnyArguments().Returns(developer);

            await _developerService.DeleteSelectedDeveloperAsync(mockGuid);

            A.CallTo(() => _gameServiceFake.DeleteGamesForRemovedDeveloperAsync(mockGuid)).MustHaveHappened();
            
        }

        [Fact]
        public async Task DeleteSelectedDeveloperAsync_Negative_DevelopersIdDoNotExist_ExceptionExpected()
        {
            Developer developer = null;

            A.CallTo(() => _developerRepositoryFake.GetByIdAsync(Guid.NewGuid(), false)).WithAnyArguments().Returns(developer);

            await Assert.ThrowsAsync<NotFoundException>( async () => await _developerService.DeleteSelectedDeveloperAsync(Guid.NewGuid()));

        }
    }
}
