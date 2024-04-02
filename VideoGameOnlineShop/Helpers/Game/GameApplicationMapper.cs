using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopApplication.Helpers.Game
{
    public class GameApplicationMapper
    {
        public static GameDataModel MapGameSubmissionDtoToGameDataModel(GameSubmissionDto gameSubmissionDto)
        {
            GameDataModel gameSubmissionDataModel = new GameDataModel
            {
                Name = gameSubmissionDto.Name,
                Description = gameSubmissionDto.Description,
                MatureRating = gameSubmissionDto.MatureRating,
                Rating = 0,
                Price = gameSubmissionDto.Price,
                ImageUrl = gameSubmissionDto.ImageUrl ?? null,
                DeveloperId = Guid.Parse(gameSubmissionDto.DeveloperId),
                CodeGenre = gameSubmissionDto.CodeGenre,
                DateTimeCreated = DateTime.Now,
                DateTimeUpdated = DateTime.Now,

            };

            return gameSubmissionDataModel;
        }

        public static GameDataModel MapGameUpdateDtoToGameDataModel(GameUpdateDto gameUpdateDto)
        {
            GameDataModel gameSubmissionDataModel = new GameDataModel
            {
                Id = Guid.Parse(gameUpdateDto.Id),
                Name = gameUpdateDto.Name,
                Description = gameUpdateDto.Description,
                MatureRating = gameUpdateDto.MatureRating,
                Price = gameUpdateDto.Price,
                ImageUrl = gameUpdateDto.ImageUrl ?? null,
                DeveloperId = Guid.Parse(gameUpdateDto.DeveloperId),
                CodeGenre = gameUpdateDto.CodeGenre
            };

            return gameSubmissionDataModel;
        }

        public static GameApplicationViewModel MapGameDataModelToGameViewModel(GameDataModel gameSubmissionDataModel)
        {
            GameApplicationViewModel gameSubmissionViewModel = new GameApplicationViewModel
            {
                Id = gameSubmissionDataModel.Id,
                Name = gameSubmissionDataModel.Name,
                Description = gameSubmissionDataModel.Description,
                MatureRating = gameSubmissionDataModel.MatureRating,
                Rating = gameSubmissionDataModel.Rating,
                Price = gameSubmissionDataModel.Price,
                ImageUrl = gameSubmissionDataModel.ImageUrl ?? null,
                DeveloperId = gameSubmissionDataModel.DeveloperId.ToString(),
                CodeGenre = gameSubmissionDataModel.CodeGenre,
                DateTimeCreated = gameSubmissionDataModel.DateTimeCreated,
                DateTimeUpdated = gameSubmissionDataModel.DateTimeUpdated,

            };

            return gameSubmissionViewModel;
        }
    }
}
