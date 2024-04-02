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

            RuleFor(x => x.CodeGenre).NotNull().WithMessage("CodeGenre - Must not be null");

            RuleFor(x => x.CodeGenre).Must(BeAbleToSplitByComma).WithMessage("CodeGenre - Input string must be able to split by comma");

            RuleFor(x => x.DeveloperId).NotNull().NotEmpty().WithMessage("DeveloperId - Must not be null");

            RuleFor(x => x.DeveloperId).Must(x => Guid.TryParse(x, out Guid _)).WithMessage("DeveloperId - Please Insert a Valid Guid Format");

            bool BeAbleToSplitByComma(string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                    return false;

                // Check if the string can be split by comma
                return input.Split(',').Length > 1;
            }
        }


    }
}
