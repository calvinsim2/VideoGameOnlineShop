﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopDomain.Common.Exceptions;
using VideoGameOnlineShopDomain.Constants;
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
            try
            {
                Guid parseId = _commonUtilityMethods.ConvertStringToGuid(id);
                var game = await _gameApplicationService.GetExplicitGameAsync(parseId);

                return Ok(game);
            }
            catch (BadRequestException badRequestException)
            {
                return BadRequest(badRequestException.Message);
            }
            catch (NotFoundException notFoundException)
            {
                return NotFound(notFoundException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = Messages.UnexpectedErrorOccured, details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGameAsync([FromBody] GameSubmissionDto gameSubmissionDto)
        {
            try
            {
                await _gameSubmissionDtoValidator.ValidateAsync(gameSubmissionDto, options => options.ThrowOnFailures());
                await _gameApplicationService.AddGameAsync(gameSubmissionDto);
                return Ok(gameSubmissionDto);
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(new { message = "Validation failed", details = errors });
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, new { message = Messages.UnexpectedErrorOccured, details = ex.Message });
            }
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
            Guid parseId = _commonUtilityMethods.ConvertStringToGuid(id);
            await _gameApplicationService.DeleteSelectedGameAsync(parseId);
            return Ok();
        }
    }
}
