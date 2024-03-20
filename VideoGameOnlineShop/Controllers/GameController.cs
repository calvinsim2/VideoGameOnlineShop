using Microsoft.AspNetCore.Mvc;
using VideoGameOnlineShopDomain.DomainModels;
using VideoGameOnlineShopDomain.Interfaces;

namespace VideoGameOnlineShopApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGamesAsync()
        {
            var games = await _gameService.GetAllExistingGamesAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodByIdAsync(string id)
        {
            var game = await _gameService.GetExplicitDeveloperAsync(Guid.Parse(id));
            if (game is null)
            {
                return NotFound(id);
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> AddGameAsync([FromBody] Game game)
        {
            await _gameService.AddGameAsync(game);
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExistingFoodAsync(string id)
        {
            await _gameService.DeleteSelectedGameAsync(Guid.Parse(id));
            return Ok();
        }
    }
}
