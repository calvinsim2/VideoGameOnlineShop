using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperApplicationService _developerApplicationService;
        private readonly IValidator<DeveloperSubmissionDto> _developerSubmissionDtoValidator;
        private readonly IValidator<DeveloperUpdateDto> _developerUpdateDtoValidator;
        private readonly ICommonUtilityMethods _commonUtilityMethods;

        public DeveloperController(IDeveloperApplicationService developerApplicationService,
                                   IValidator<DeveloperSubmissionDto> developerSubmissionDtoValidator,
                                   IValidator<DeveloperUpdateDto> developerUpdateDtoValidator,
                                   ICommonUtilityMethods commonUtilityMethods)
        {
            _developerApplicationService = developerApplicationService;
            _developerSubmissionDtoValidator = developerSubmissionDtoValidator;
            _developerUpdateDtoValidator = developerUpdateDtoValidator;
            _commonUtilityMethods = commonUtilityMethods;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDevelopersAsync()
        {
            var developers = await _developerApplicationService.GetAllDevelopersAsync();

            return Ok(developers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeveloperByIdAsync(string id)
        {
            Guid parseId = _commonUtilityMethods.ValidateStringIfConvertableToGuid(id);
            var developer = await _developerApplicationService.GetExplicitDeveloperAsync(parseId);

            return Ok(developer);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDeveloperAsync([FromBody] DeveloperSubmissionDto developerSubmissionDto)
        {
            await _developerSubmissionDtoValidator.ValidateAsync(developerSubmissionDto, options => options.ThrowOnFailures());
            await _developerApplicationService.AddDeveloperAsync(developerSubmissionDto);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDeveloperAsync([FromBody] DeveloperUpdateDto developerUpdateDto)
        {
            await _developerUpdateDtoValidator.ValidateAsync(developerUpdateDto, options => options.ThrowOnFailures());
            await _developerApplicationService.UpdateSelectedDeveloperAsync(developerUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExistingDeveloperAsync(string id)
        {
            Guid parseId = _commonUtilityMethods.ValidateStringIfConvertableToGuid(id);
            await _developerApplicationService.DeleteSelectedDeveloperAsync(parseId);
            return Ok();
        }
    }
}
