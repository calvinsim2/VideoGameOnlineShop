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
        private readonly IValidator<GameSubmissionDto> _gameDtoValidator;
        private readonly ICommonUtilityMethods _commonUtilityMethods;
        public GameController(IGameApplicationService gameApplicationService,
                              IValidator<GameSubmissionDto> gameDtoValidator,
                              ICommonUtilityMethods commonUtilityMethods)
        {
            _gameApplicationService = gameApplicationService;
            _gameDtoValidator = gameDtoValidator;
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
            await _gameDtoValidator.ValidateAsync(gameSubmissionDto, options => options.ThrowOnFailures());
            await _gameApplicationService.AddGameAsync(gameSubmissionDto);
            return Ok(gameSubmissionDto);
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
