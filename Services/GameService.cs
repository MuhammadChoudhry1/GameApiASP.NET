using System.Text.Json;
using gamestore.api.Models;

namespace gamestore.api.Services;

public interface IGameService
{
    Task<IEnumerable<Game>> GetAllGamesAsync();
    Task<Game?> GetGameByIdAsync(int id);
    Task<Game> CreateGameAsync(Game game);
    Task<Game?> UpdateGameAsync(int id, Game game);
    Task<bool> DeleteGameAsync(int id);
}

public class GameService : IGameService
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonOptions;

    public GameService(IConfiguration configuration)
    {
        _filePath = configuration["GameDataFile"] ?? "games.json";
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<IEnumerable<Game>> GetAllGamesAsync()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Game>();
        }

        var jsonData = await File.ReadAllTextAsync(_filePath);
        if (string.IsNullOrEmpty(jsonData))
        {
            return new List<Game>();
        }

        var games = JsonSerializer.Deserialize<List<Game>>(jsonData, _jsonOptions);
        return games ?? new List<Game>();
    }

    public async Task<Game?> GetGameByIdAsync(int id)
    {
        var games = await GetAllGamesAsync();
        return games.FirstOrDefault(g => g.Id == id);
    }

    public async Task<Game> CreateGameAsync(Game game)
    {
        var games = (await GetAllGamesAsync()).ToList();
        
        // Auto-increment ID
        game.Id = games.Count > 0 ? games.Max(g => g.Id) + 1 : 1;
        
        games.Add(game);
        await SaveGamesAsync(games);
        
        return game;
    }

    public async Task<Game?> UpdateGameAsync(int id, Game game)
    {
        var games = (await GetAllGamesAsync()).ToList();
        var existingGame = games.FirstOrDefault(g => g.Id == id);
        
        if (existingGame == null)
        {
            return null;
        }

        // Update properties
        existingGame.Name = game.Name;
        existingGame.Genre = game.Genre;
        existingGame.Platform = game.Platform;
        existingGame.Price = game.Price;
        existingGame.Developer = game.Developer;
        existingGame.Publisher = game.Publisher;
        existingGame.ReleaseDate = game.ReleaseDate;
        existingGame.Description = game.Description;
        existingGame.Rating = game.Rating;

        await SaveGamesAsync(games);
        return existingGame;
    }

    public async Task<bool> DeleteGameAsync(int id)
    {
        var games = (await GetAllGamesAsync()).ToList();
        var gameToRemove = games.FirstOrDefault(g => g.Id == id);
        
        if (gameToRemove == null)
        {
            return false;
        }

        games.Remove(gameToRemove);
        await SaveGamesAsync(games);
        return true;
    }

    private async Task SaveGamesAsync(List<Game> games)
    {
        var jsonData = JsonSerializer.Serialize(games, _jsonOptions);
        await File.WriteAllTextAsync(_filePath, jsonData);
    }
}
