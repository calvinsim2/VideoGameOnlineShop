using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.DataModels;

namespace VideoGameOnlineShopApplication.Helpers.Game
{
    public class GameApplicationMapper
    {
        public static GameSubmissionDataModel MapGameDtoToGameDataModel(GameSubmissionDto gameSubmissionDto)
        {
            GameSubmissionDataModel gameSubmissionDataModel = new GameSubmissionDataModel
            {
                Name = gameSubmissionDto.Name,
                Description = gameSubmissionDto.Description,
                MatureRating = gameSubmissionDto.MatureRating,
                Rating = 0,
                Price = gameSubmissionDto.Price,
                ImageUrl = gameSubmissionDto.ImageUrl ?? null,
                DeveloperId = gameSubmissionDto.DeveloperId,
                CodeGenre = gameSubmissionDto.CodeGenre,
                DateTimeCreated = DateTime.Now,
                DateTimeUpdated = DateTime.Now,

            };

            return gameSubmissionDataModel;
        }

        public static GameApplicationViewModel MapGameDataModelToGameViewModel(GameSubmissionDataModel gameSubmissionDataModel)
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
                DeveloperId = gameSubmissionDataModel.DeveloperId,
                CodeGenre = gameSubmissionDataModel.CodeGenre,
                DateTimeCreated = gameSubmissionDataModel.DateTimeCreated,
                DateTimeUpdated = gameSubmissionDataModel.DateTimeUpdated,

            };

            return gameSubmissionViewModel;
        }
    }
}
