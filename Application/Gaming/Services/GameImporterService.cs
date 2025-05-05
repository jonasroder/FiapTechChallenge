using Application.Gaming.Contracts;
using Application.SharedKernel.Common;
using Core.Gaming.Entities;
using Core.Gaming.Repositories;
using Infrastructure.SharedKernel.Logger;
using System.Text.Json;

namespace Application.Gaming.Services;

public class GameImporterService : IGameImporterService
{
    private readonly IRawgService _rawgService;
    private readonly IGameRepository _gameRepo;
    private readonly BaseLogger<GameImporterService> _logger;

    public GameImporterService(IRawgService rawgService, IGameRepository gameRepo, BaseLogger<GameImporterService> logger)
    {
        _rawgService = rawgService;
        _gameRepo = gameRepo;
        _logger = logger;
    }

    public async Task<Result<string>> ImportGamesAsync()
    {
        ResultLoggerContext.Set(_logger);

        _logger.LogInformation("Iniciando importação de jogos da RAWG...");

        var rawResult = await _rawgService.GetGamesAsync();

        if (!rawResult.IsSuccess)
            return Result<string>.Failure<GameImporterService>("Falha ao obter dados da RAWG.", "RAWG_IMPORT_ERROR");

        try
        {
            var json = (JsonElement)rawResult.Data!;
            var results = json.GetProperty("results");

            var games = new List<Game>();

            foreach (var item in results.EnumerateArray())
            {
                var game = new Game
                {
                    Title = item.GetProperty("name").GetString() ?? "Desconhecido",
                    Description = null,
                    ImageUrl = item.GetProperty("background_image").GetString(),
                    Rating = item.TryGetProperty("rating", out var rating) ? rating.GetDecimal() : null,
                    ReleaseDate = item.TryGetProperty("released", out var released) && DateTime.TryParse(released.GetString(), out var date) ? date : DateTime.MinValue,
                    Platforms = item.TryGetProperty("platforms", out var platforms)
                        ? platforms.EnumerateArray()
                            .Select(p => new GamePlatform
                            {
                                Name = p.GetProperty("platform").GetProperty("name").GetString() ?? "N/A"
                            }).ToList()
                        : new List<GamePlatform>(),
                    Genres = item.TryGetProperty("genres", out var genres)
                        ? genres.EnumerateArray()
                            .Select(g => new GameGenre
                            {
                                Name = g.GetProperty("name").GetString() ?? "N/A"
                            }).ToList()
                        : new List<GameGenre>(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = null,
                    DeletedAt = null
                };

                games.Add(game);
            }

            await _gameRepo.CadastrarEmLote(games);

            _logger.LogInformation("Importação finalizada com sucesso.");
            return Result<string>.Success<GameImporterService>($"Importados {games.Count} jogos com sucesso.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro durante o parse dos dados: {ex.Message}");
            return Result<string>.InternalError<GameImporterService>("Erro ao processar dados da RAWG.");
        }
    }

}
