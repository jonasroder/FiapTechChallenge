using Application.SharedKernel.Common;

namespace Application.Gaming.Contracts;

public interface IRawgService
{
    Task<Result<object>> GetGamesAsync();
}