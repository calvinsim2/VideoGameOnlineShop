using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto;

namespace VideoGameOnlineShopApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperApplicationService _developerApplicationService;
        private readonly IValidator<DeveloperSubmissionDto> _developerDtoValidator;

        public DeveloperController(IDeveloperApplicationService developerApplicationService,
                                   IValidator<DeveloperSubmissionDto> developerDtoValidator)
        {
            _developerApplicationService = developerApplicationService;
            _developerDtoValidator = developerDtoValidator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeveloperByIdAsync(string id)
        {
            var developer = await _developerApplicationService.GetExplicitDeveloperAsync(Guid.Parse(id));

            return Ok(developer);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDeveloperAsync([FromBody] DeveloperSubmissionDto developerSubmissionDto)
        {
            await _developerDtoValidator.ValidateAsync(developerSubmissionDto, options => options.ThrowOnFailures());
            await _developerApplicationService.AddDeveloperAsync(developerSubmissionDto);
            return Ok(developerSubmissionDto);
        }


    }
}
