using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopDomain.Helpers.Game
{
    public class GameDomainMapper
    {
        public static DomainModels.Game MapGameDtoToGameDataModel(GameSubmissionDataModel gameSubmissionDataModel)
        {
            DomainModels.Game game = new DomainModels.Game
            {
                Name = gameSubmissionDataModel.Name,
                Description = gameSubmissionDataModel.Description,
                MatureRating = gameSubmissionDataModel.MatureRating,
                Rating = 0,
                Price = gameSubmissionDataModel.Price,
                ImageUrl = gameSubmissionDataModel.ImageUrl ?? null,
                DeveloperId = gameSubmissionDataModel.DeveloperId,
                CodeGenre = gameSubmissionDataModel.CodeGenre,
                DateTimeCreated = gameSubmissionDataModel.DateTimeCreated,
                DateTimeUpdated = gameSubmissionDataModel.DateTimeUpdated,

            };

            return game;
        }

        public static GameSubmissionDataModel MapGameToGameDataModel(DomainModels.Game game)
        {
            GameSubmissionDataModel gameSubmissionDataModel = new GameSubmissionDataModel
            {
                Id = game.Id,                Name = game.Name,
                Description = game.Description,
                MatureRating = game.MatureRating,
                Rating = game.Rating,
                Price = game.Price,
                ImageUrl = game.ImageUrl ?? null,
                DeveloperId = game.DeveloperId,
                CodeGenre = game.CodeGenre,
                DateTimeCreated = game.DateTimeCreated,
                DateTimeUpdated = game.DateTimeUpdated,

            };

            return gameSubmissionDataModel;
        }
    }
}
