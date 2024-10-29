using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Models.ViewModels;
using VideoGameOnlineShopDomain.Common.Exceptions;
using VideoGameOnlineShopDomain.Constants;

namespace VideoGameOnlineShopApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;
        private readonly IValidator<RegisterUserDto> _registerUserDtoValidator;
        private readonly IValidator<LoginDto> _loginDtoValidator;

        public UserController(IUserApplicationService userApplicationService,
                              IValidator<RegisterUserDto> registerUserDtoValidator,
                              IValidator<LoginDto> loginDtoValidator)
        {
            _userApplicationService = userApplicationService;
            _registerUserDtoValidator = registerUserDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            try
            {
                await _registerUserDtoValidator.ValidateAsync(registerUserDto, options => options.ThrowOnFailures());
                await _userApplicationService.RegisterUserAsync(registerUserDto);
                return Ok();
            }
            catch (ValidationException validationException)
            {
                var errors = validationException.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(new { message = "Validation failed", details = errors });
            }
            catch (BadRequestException badRequestException)
            {
                return BadRequest(badRequestException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = Messages.UnexpectedErrorOccured, details = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                await _loginDtoValidator.ValidateAsync(loginDto, options => options.ThrowOnFailures());
                AuthViewModel authViewModel = await _userApplicationService.LoginUserAsync(loginDto);
                return Ok(authViewModel);
            }
            catch (ValidationException validationException)
            {
                var errors = validationException.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(new { message = "Validation failed", details = errors });
            }
            catch (BadRequestException badRequestException)
            {
                return BadRequest(badRequestException.Message);
            }
            catch (NotFoundException notFoundException)
            {
                return NotFound(notFoundException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = Messages.UnexpectedErrorOccured, details = ex.Message });
            }
        }
    }
}
