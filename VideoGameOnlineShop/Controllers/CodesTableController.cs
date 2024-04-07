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

        #region CodeDecodeMatureRating

        [HttpGet("matureRating")]
        public async Task<IActionResult> GetAllCodeMatureRatingAsync()
        {
            var codeMatureRatings = await _codesTableApplicationService.GetAllCodeMatureRatingAsync();

            return Ok(codeMatureRatings);
        }

        [HttpGet("matureRating/{code}")]
        public async Task<IActionResult> GetExplicitCodeMatureRatingAsync(string code)
        {
            string trimAndCapsCode = _commonUtilityMethods.RemoveEmptySpaceAndCapitalizeString(code);
            var codeMatureRating = await _codesTableApplicationService.GetCodeMatureRatingByCodeAsync(trimAndCapsCode);

            return Ok(codeMatureRating);
        }

        [HttpPost("matureRating")]
        public async Task<IActionResult> AddCodeMatureRatingAsync(CodesTableDto codesTableDto)
        {
            await _codesTableApplicationService.AddCodeMatureRatingAsync(codesTableDto);

            return Ok();
        }

        [HttpDelete("matureRating")]
        public async Task<IActionResult> DeleteCodeMatureRatingAsync(string id)
        {
            Guid parseId = _commonUtilityMethods.ValidateStringIfConvertableToGuid(id);
            await _codesTableApplicationService.DeleteExplicitCodeMatureRatingAsync(parseId);

            return Ok();
        }

        #endregion

        #region CodeDecodeGenre

        [HttpGet("genre")]
        public async Task<IActionResult> GetAllCodeGenreAsync()
        {
            var codeMatureRatings = await _codesTableApplicationService.GetAllCodeGenreAsync();

            return Ok(codeMatureRatings);
        }

        [HttpGet("genre/{code}")]
        public async Task<IActionResult> GetExplicitCodeGenreAsync(string code)
        {
            string trimAndCapsCode = _commonUtilityMethods.RemoveEmptySpaceAndCapitalizeString(code);
            var codeMatureRating = await _codesTableApplicationService.GetCodeGenreByCodeAsync(trimAndCapsCode);

            return Ok(codeMatureRating);
        }

        [HttpPost("genre")]
        public async Task<IActionResult> AddCodeGenreAsync(CodesTableDto codesTableDto)
        {
            await _codesTableApplicationService.AddCodeGenreAsync(codesTableDto);

            return Ok();
        }

        [HttpDelete("genre")]
        public async Task<IActionResult> DeleteCodeGenreAsync(string id)
        {
            Guid parseId = _commonUtilityMethods.ValidateStringIfConvertableToGuid(id);
            await _codesTableApplicationService.DeleteExplicitCodeGenreAsync(parseId);

            return Ok();
        }

        #endregion
    }
}
