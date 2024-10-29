using FluentValidation;
using VideoGameOnlineShopApplication.Models.Dto;

namespace VideoGameOnlineShopApplication.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator() 
        {
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Name - cannot be empty");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password - cannot be empty");
            RuleFor(x => x.DisplayName).NotNull().NotEmpty().WithMessage("DisplayName - cannot be empty");
        }
    }
}
