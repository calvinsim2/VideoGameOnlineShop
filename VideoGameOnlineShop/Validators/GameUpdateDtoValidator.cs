using FluentValidation;
using VideoGameOnlineShopApplication.Models.Dto;

namespace VideoGameOnlineShopApplication.Validators
{
    public class GameUpdateDtoValidator : AbstractValidator<GameUpdateDto>
    {
        public GameUpdateDtoValidator() 
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Name - cannot be empty");

            RuleFor(x => x.Id).Must(x => Guid.TryParse(x, out Guid _)).WithMessage("Id - Please Insert a Valid Guid Format");

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name - cannot be empty");

            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Description - cannot be empty");

            RuleFor(x => x.Price).NotNull().GreaterThanOrEqualTo(0).WithMessage("Price - Must be 0 or greater");

            RuleFor(x => x.DeveloperId).NotNull().WithMessage("Price - Must be 0 or greater");

            RuleFor(x => x.CodeMatureRating).NotNull().NotEmpty().WithMessage("MatureRating - Must not be null or empty");

            RuleFor(x => x.CodeGenre).NotNull().NotEmpty().WithMessage("CodeGenre - Must not be null or empty");

            RuleFor(x => x.CodePlatform).NotNull().NotEmpty().WithMessage("CodePlatform - Must not be null or empty");

            RuleFor(x => x.DeveloperId).NotNull().NotEmpty().WithMessage("DeveloperId - Must not be null");

            RuleFor(x => x.DeveloperId).Must(x => Guid.TryParse(x, out Guid _)).WithMessage("DeveloperId - Please Insert a Valid Guid Format");
        }


    }
}
