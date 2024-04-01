using FluentValidation;
using VideoGameOnlineShopApplication.Models.Dto;

namespace VideoGameOnlineShopApplication.Validators
{
    public class DeveloperSubmissionDtoValidator : AbstractValidator<DeveloperSubmissionDto>
    {
        public DeveloperSubmissionDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name - cannot be empty");
        }
    }
}
