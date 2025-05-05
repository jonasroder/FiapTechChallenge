using Core.Gaming.Entities;
using Core.Gaming.Repositories;
using Infrastructure.SharedKernel.repositories;

namespace Infrastructure.Gaming.repositories;

public class GameRepository : EFRepository<Game>, IGameRepository
{
    public GameRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task CadastrarEmLote(IEnumerable<Game> games)
    {
        _dbSet.AddRange(games);
        await _context.SaveChangesAsync();
    }

}
