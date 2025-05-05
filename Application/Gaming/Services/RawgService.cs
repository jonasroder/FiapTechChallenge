using Application.Gaming.Contracts;
using Application.SharedKernel.Common;
using Infrastructure.SharedKernel.Logger;
using System.Text.Json;

namespace Application.Gaming.Services;

public class RawgService : IRawgService
{
    private readonly HttpClient _httpClient;
    private readonly BaseLogger<RawgService> _logger;
    private const string ApiKey = "47355235a39f455a82293bf738774400";

    public RawgService(HttpClient httpClient, BaseLogger<RawgService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }



    public async Task<Result<object>> GetGamesAsync()
    {
        ResultLoggerContext.Set(_logger);

        try
        {
            _logger.LogInformation("Consultando jogos na RAWG API...");

            var response = await _httpClient.GetAsync($"https://api.rawg.io/api/games?key={ApiKey}&page_size=100");

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning($"RAWG retornou status {response.StatusCode}");
                return Result<object>.Failure<RawgService>("Erro ao acessar a RAWG API.", "RAWG_UNAVAILABLE");
            }

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<object>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            _logger.LogInformation("Dados obtidos com sucesso da RAWG.");
            return Result<object>.Success<RawgService>(json);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao consultar RAWG: {ex.Message}");
            return Result<object>.InternalError<RawgService>("Erro inesperado ao consultar a API da RAWG.");
        }
    }
}
