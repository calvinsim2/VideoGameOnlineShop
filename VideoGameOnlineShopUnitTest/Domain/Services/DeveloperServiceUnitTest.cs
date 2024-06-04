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
    }
}
