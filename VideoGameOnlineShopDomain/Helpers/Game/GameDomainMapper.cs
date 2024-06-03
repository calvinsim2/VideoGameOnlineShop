using VideoGameOnlineShopDomain.Constants;
using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopDomain.Helpers.Game
{
    public class GameDomainMapper
    {
        public static DomainModels.Game MapGameDataModelToGame(GameDataModel gameSubmissionDataModel)
        {
            DomainModels.Game game = new DomainModels.Game
            {
                Name = gameSubmissionDataModel.Name,
                Description = gameSubmissionDataModel.Description,
                CodeMatureRating = gameSubmissionDataModel.CodeMatureRating,
                Rating = 0,
                Price = gameSubmissionDataModel.Price,
                ImageUrl = string.IsNullOrEmpty(gameSubmissionDataModel.ImageUrl) ? 
                           DefaultImage.Logo : gameSubmissionDataModel.ImageUrl,
                DeveloperId = gameSubmissionDataModel.DeveloperId,
                CodeGenre = gameSubmissionDataModel.CodeGenre,
                CodePlatform = gameSubmissionDataModel.CodePlatform,
                DateTimeCreated = gameSubmissionDataModel.DateTimeCreated,
                DateTimeUpdated = gameSubmissionDataModel.DateTimeUpdated,

            };

            return game;
        }

        public static GameDataModel MapGameToGameDataModel(DomainModels.Game game)
        {
            GameDataModel gameSubmissionDataModel = new GameDataModel
            {
                Id = game.Id,                Name = game.Name,
                Description = game.Description,
                CodeMatureRating = game.CodeMatureRating,
                Rating = game.Rating,
                Price = game.Price,
                ImageUrl = game.ImageUrl ?? null,
                DeveloperId = game.DeveloperId,
                CodeGenre = game.CodeGenre,
                CodePlatform = game.CodePlatform,
                DateTimeCreated = game.DateTimeCreated,
                DateTimeUpdated = game.DateTimeUpdated,

            };

            return gameSubmissionDataModel;
        }
    }
}
