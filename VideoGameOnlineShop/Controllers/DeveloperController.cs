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
        private readonly IValidator<DeveloperSubmissionDto> _developerDtoValidator;
        private readonly ICommonUtilityMethods _commonUtilityMethods;

        public DeveloperController(IDeveloperApplicationService developerApplicationService,
                                   IValidator<DeveloperSubmissionDto> developerDtoValidator,
                                   ICommonUtilityMethods commonUtilityMethods)
        {
            _developerApplicationService = developerApplicationService;
            _developerDtoValidator = developerDtoValidator;
            _commonUtilityMethods = commonUtilityMethods;
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
            await _developerDtoValidator.ValidateAsync(developerSubmissionDto, options => options.ThrowOnFailures());
            await _developerApplicationService.AddDeveloperAsync(developerSubmissionDto);
            return Ok(developerSubmissionDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExistingGameAsync(string id)
        {
            Guid parseId = _commonUtilityMethods.ValidateStringIfConvertableToGuid(id);
            await _developerApplicationService.DeleteSelectedDeveloperAsync(parseId);
            return Ok();
        }
    }
}
