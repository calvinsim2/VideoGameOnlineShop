using FluentValidation;
using VideoGameOnlineShopApplication.Models.Dto;

namespace VideoGameOnlineShopApplication.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator() 
        {
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Name - cannot be empty");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password - cannot be empty");
        }
    }
}
