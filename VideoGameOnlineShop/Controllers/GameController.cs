using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopDomain.Interfaces;

namespace VideoGameOnlineShopApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IGameApplicationService _gameApplicationService;
        private readonly IValidator<GameSubmissionDto> _gameDtoValidator;

        public GameController(IGameService gameService,
                              IGameApplicationService gameApplicationService,
                              IValidator<GameSubmissionDto> gameDtoValidator)
        {
            _gameService = gameService;
            _gameApplicationService = gameApplicationService;
            _gameDtoValidator = gameDtoValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGamesAsync()
        {
            var games = await _gameService.GetAllExistingGamesAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameByIdAsync(string id)
        {
            var game = await _gameService.GetExplicitDeveloperAsync(Guid.Parse(id));
            if (game is null)
            {
                return NotFound(id);
            }
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
        public async Task<IActionResult> DeleteExistingFoodAsync(string id)
        {
            await _gameService.DeleteSelectedGameAsync(Guid.Parse(id));
            return Ok();
        }
    }
}
