using VideoGameOnlineShopDomain.DataModels;
using VideoGameOnlineShopDomain.Helpers.Game;

namespace VideoGameOnlineShopUnitTest.Domain.Helpers.Game
{
    public class GameDomainMapperUnitTest
    {
        [Fact]
        public void MapGameDataModelToGame_Positive_GameDtoProvided_ReturnGameDataModel()
        {
            // Arrange
            GameDataModel gameDataModelMock = new GameDataModel
            {
                Name = "test",
                Description = "test",
                Price = 5,
                CodeGenre = "1,2,3,4,5",
                CodeMatureRating = "1,2,3,4,5",
                CodePlatform = "1,2,3,4,5",
            };

            // Act
            var result = GameDomainMapper.MapGameDataModelToGame(gameDataModelMock);

            // Assert
            Assert.IsType<VideoGameOnlineShopDomain.DomainModels.Game>(result);
            Assert.Equal(gameDataModelMock.Name, result.Name);
            Assert.Equal(gameDataModelMock.Description, result.Description);
            Assert.Equal(gameDataModelMock.Price, result.Price);
            Assert.Equal(gameDataModelMock.CodeGenre, result.CodeGenre);
            Assert.Equal(gameDataModelMock.CodeMatureRating, result.CodeMatureRating);
            Assert.Equal(gameDataModelMock.CodePlatform, result.CodePlatform);

        }

        [Fact]
        public void MapGameToGameDataModel_Positive_GameModelProvided_ReturnGameDataModel()
        {
            // Arrange
            VideoGameOnlineShopDomain.DomainModels.Game gameMock = new VideoGameOnlineShopDomain.DomainModels.Game
            {
                Name = "test",
                Description = "test",
                Price = 5,
                CodeGenre = "1,2,3,4,5",
                CodeMatureRating = "1,2,3,4,5",
                CodePlatform = "1,2,3,4,5",
            };

            // Act
            var result = GameDomainMapper.MapGameToGameDataModel(gameMock);

            // Assert
            Assert.IsType<GameDataModel>(result);
            Assert.Equal(gameMock.Name, result.Name);
            Assert.Equal(gameMock.Description, result.Description);
            Assert.Equal(gameMock.Price, result.Price);
            Assert.Equal(gameMock.CodeGenre, result.CodeGenre);
            Assert.Equal(gameMock.CodeMatureRating, result.CodeMatureRating);
            Assert.Equal(gameMock.CodePlatform, result.CodePlatform);
        }
    }
}
