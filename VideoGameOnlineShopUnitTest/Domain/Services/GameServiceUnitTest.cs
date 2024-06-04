using FakeItEasy;
using VideoGameOnlineShopDomain.Interfaces;
using VideoGameOnlineShopDomain.Interfaces.Common;
using VideoGameOnlineShopDomain.Services;

namespace VideoGameOnlineShopUnitTest.Domain.Services
{
    public class GameServiceUnitTest
    {
        public static readonly IGameRepository _gameRepositoryMock = A.Fake<IGameRepository>();
        public static readonly IDeveloperRepository _developerRepositoryMock = A.Fake<IDeveloperRepository>();
        public static readonly ICommonUtilityMethods _commonUtilityMethodsMock = A.Fake<ICommonUtilityMethods>();
        public readonly GameService gameService = new GameService(_gameRepositoryMock, 
                                                                  _developerRepositoryMock,
                                                                  _commonUtilityMethodsMock);
    }
}
