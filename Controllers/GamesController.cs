using Microsoft.AspNetCore.Mvc;
using gamestore.api.Models;
using gamestore.api.Services;

namespace gamestore.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;

    public GamesController(IGameService gameService)
    {
        _gameService = gameService;
    }

    /// <summary>
    /// Get all games
    /// </summary>
    /// <returns>List of all games</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Game>>> GetAllGames()
    {
        var games = await _gameService.GetAllGamesAsync();
        return Ok(games);
    }

    /// <summary>
    /// Get a specific game by ID
    /// </summary>
    /// <param name="id">Game ID</param>
    /// <returns>Game details</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        var game = await _gameService.GetGameByIdAsync(id);
        
        if (game == null)
        {
            return NotFound($"Game with ID {id} not found.");
        }

        return Ok(game);
    }

    /// <summary>
    /// Create a new game
    /// </summary>
    /// <param name="game">Game details</param>
    /// <returns>Created game</returns>
    [HttpPost]
    public async Task<ActionResult<Game>> CreateGame([FromBody] Game game)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdGame = await _gameService.CreateGameAsync(game);
        return CreatedAtAction(nameof(GetGame), new { id = createdGame.Id }, createdGame);
    }

    /// <summary>
    /// Update an existing game
    /// </summary>
    /// <param name="id">Game ID</param>
    /// <param name="game">Updated game details</param>
    /// <returns>Updated game</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<Game>> UpdateGame(int id, [FromBody] Game game)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedGame = await _gameService.UpdateGameAsync(id, game);
        
        if (updatedGame == null)
        {
            return NotFound($"Game with ID {id} not found.");
        }

        return Ok(updatedGame);
    }

    /// <summary>
    /// Delete a game
    /// </summary>
    /// <param name="id">Game ID</param>
    /// <returns>Success status</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGame(int id)
    {
        var success = await _gameService.DeleteGameAsync(id);
        
        if (!success)
        {
            return NotFound($"Game with ID {id} not found.");
        }

        return NoContent();
    }
}
