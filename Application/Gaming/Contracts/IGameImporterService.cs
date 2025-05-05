using Application.SharedKernel.Common;

namespace Application.Gaming.Contracts;

public interface IGameImporterService
{
    Task<Result<string>> ImportGamesAsync();
}
