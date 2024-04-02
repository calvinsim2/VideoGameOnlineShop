using FluentValidation;
using VideoGameOnlineShopApplication.Models.Dto;

namespace VideoGameOnlineShopApplication.Validators
{
    public class DeveloperUpdateDtoValidator : AbstractValidator<DeveloperUpdateDto>
    {
        public DeveloperUpdateDtoValidator() 
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Name - cannot be empty");

            RuleFor(x => x.Id).Must(x => Guid.TryParse(x, out Guid _)).WithMessage("Id - Please Insert a Valid Guid Format");

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name - cannot be empty");
        }
    }
}
