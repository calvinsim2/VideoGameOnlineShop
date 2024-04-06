using Microsoft.AspNetCore.Mvc;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto.CodesTable;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopApplication.Controllers
{
    public class CodesTableController : ControllerBase
    {
        private readonly ICodesTableApplicationService _codesTableApplicationService;
        private readonly ICommonUtilityMethods _commonUtilityMethods;

        public CodesTableController(ICodesTableApplicationService codesTableApplicationService,
                                    ICommonUtilityMethods commonUtilityMethods) 
        {
            _codesTableApplicationService = codesTableApplicationService;
            _commonUtilityMethods = commonUtilityMethods;
        }

        [HttpGet("matureRating")]
        public async Task<IActionResult> GetExplicitCodeMatureRatingAsync()
        {
            var codeMatureRatings = await _codesTableApplicationService.GetAllCodeMatureRatingAsync();

            return Ok(codeMatureRatings);
        }

        [HttpGet("matureRating/{code}")]
        public async Task<IActionResult> GetExplicitCodeMatureRatingAsync(string code)
        {
            var codeMatureRating = await _codesTableApplicationService.GetCodeMatureRatingByCodeAsync(code);

            return Ok(codeMatureRating);
        }

        [HttpPost("matureRating")]
        public async Task<IActionResult> AddCodeMatureRatingAsync(CodesTableDto codesTableDto)
        {
            await _codesTableApplicationService.AddCodeMatureRatingAsync(codesTableDto);

            return Ok();
        }
    }
}
