using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopDomain.Interfaces.Common;

namespace VideoGameOnlineShopApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameApplicationService _gameApplicationService;
        private readonly IValidator<GameSubmissionDto> _gameSubmissionDtoValidator;
        private readonly IValidator<GameUpdateDto> _gameUpdateDtoValidator;
        private readonly ICommonUtilityMethods _commonUtilityMethods;
        public GameController(IGameApplicationService gameApplicationService,
                              IValidator<GameSubmissionDto> gameSubmissionDtoValidator,
                              IValidator<GameUpdateDto> gameUpdateDtoValidator,
                              ICommonUtilityMethods commonUtilityMethods)
        {
            _gameApplicationService = gameApplicationService;
            _gameSubmissionDtoValidator = gameSubmissionDtoValidator;
            _gameUpdateDtoValidator = gameUpdateDtoValidator;
            _commonUtilityMethods = commonUtilityMethods;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGamesAsync()
        {
            var games = await _gameApplicationService.GetAllGamesAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameByIdAsync(string id)
        {
            Guid parseId = _commonUtilityMethods.ValidateStringIfConvertableToGuid(id);
            var game = await _gameApplicationService.GetExplicitGameAsync(parseId);

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> AddGameAsync([FromBody] GameSubmissionDto gameSubmissionDto)
        {
            await _gameSubmissionDtoValidator.ValidateAsync(gameSubmissionDto, options => options.ThrowOnFailures());
            await _gameApplicationService.AddGameAsync(gameSubmissionDto);
            return Ok(gameSubmissionDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGameAsync([FromBody] GameUpdateDto gameUpdateDto)
        {
            await _gameUpdateDtoValidator.ValidateAsync(gameUpdateDto, options => options.ThrowOnFailures());
            await _gameApplicationService.UpdateSelectedGameAsync(gameUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExistingGameAsync(string id)
        {
            Guid parseId = _commonUtilityMethods.ValidateStringIfConvertableToGuid(id);
            await _gameApplicationService.DeleteSelectedGameAsync(parseId);
            return Ok();
        }
    }
}
