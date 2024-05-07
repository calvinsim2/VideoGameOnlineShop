using Microsoft.AspNetCore.Mvc;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto.CodesTable;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            _commonUtilityMethods.ValidateStringIfIsEmptyOrNull(code);
            string trimAndCapsCode = _commonUtilityMethods.RemoveEmptySpaceAndCapitalizeString(code);
            var codeMatureRating = await _codesTableApplicationService.GetCodeMatureRatingByCodeAsync(trimAndCapsCode);

            return Ok(codeMatureRating);
        }

        [HttpGet("matureRating/selected/{codes}")]
        public async Task<IActionResult> GetCodeMatureRatingByCodesAsync(string codes)
        {
            _commonUtilityMethods.ValidateStringIfIsEmptyOrNull(codes);
            string trimAndCapsCode = _commonUtilityMethods.RemoveEmptySpaceAndCapitalizeString(codes);
            var codeMatureRating = await _codesTableApplicationService.GetSelectedCodeMatureRatingByCodesAsync(trimAndCapsCode);

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
            var codeGenres = await _codesTableApplicationService.GetAllCodeGenreAsync();

            return Ok(codeGenres);
        }

        [HttpGet("genre/selected/{codes}")]
        public async Task<IActionResult> GetCodeGenreByCodesAsync(string codes)
        {
            _commonUtilityMethods.ValidateStringIfIsEmptyOrNull(codes);
            string trimAndCapsCode = _commonUtilityMethods.RemoveEmptySpaceAndCapitalizeString(codes);
            var codeGenres = await _codesTableApplicationService.GetSelectedCodeGenreByCodesAsync(trimAndCapsCode);

            return Ok(codeGenres);
        }

        [HttpGet("genre/{code}")]
        public async Task<IActionResult> GetExplicitCodeGenreAsync(string code)
        {
            _commonUtilityMethods.ValidateStringIfIsEmptyOrNull(code);
            string trimAndCapsCode = _commonUtilityMethods.RemoveEmptySpaceAndCapitalizeString(code);
            var codeGenre = await _codesTableApplicationService.GetCodeGenreByCodeAsync(trimAndCapsCode);

            return Ok(codeGenre);
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

        #region CodeDecodePlatform

        [HttpGet("platform")]
        public async Task<IActionResult> GetAllCodePlatformAsync()
        {
            var codePlatforms = await _codesTableApplicationService.GetAllCodePlatformAsync();

            return Ok(codePlatforms);
        }

        [HttpGet("platform/selected/{codes}")]
        public async Task<IActionResult> GetSelectedCodeDecodePlatformByCodesAsync(string codes)
        {
            _commonUtilityMethods.ValidateStringIfIsEmptyOrNull(codes);
            string trimAndCapsCode = _commonUtilityMethods.RemoveEmptySpaceAndCapitalizeString(codes);
            var codePlatforms = await _codesTableApplicationService.GetSelectedCodeDecodePlatformByCodesAsync(trimAndCapsCode);

            return Ok(codePlatforms);
        }

        [HttpGet("platform/{code}")]
        public async Task<IActionResult> GetExplicitCodePlatformAsync(string code)
        {
            _commonUtilityMethods.ValidateStringIfIsEmptyOrNull(code);
            string trimAndCapsCode = _commonUtilityMethods.RemoveEmptySpaceAndCapitalizeString(code);
            var codePlatform = await _codesTableApplicationService.GetCodePlatformByCodeAsync(trimAndCapsCode);

            return Ok(codePlatform);
        }

        [HttpPost("platform")]
        public async Task<IActionResult> AddCodePlatformAsync(CodesTableDto codesTableDto)
        {
            await _codesTableApplicationService.AddCodePlatformAsync(codesTableDto);

            return Ok();
        }

        [HttpDelete("platform")]
        public async Task<IActionResult> DeleteCodePlatformAsync(string id)
        {
            Guid parseId = _commonUtilityMethods.ValidateStringIfConvertableToGuid(id);
            await _codesTableApplicationService.DeleteExplicitCodePlatformAsync(parseId);

            return Ok();
        }

        #endregion
    }
}
