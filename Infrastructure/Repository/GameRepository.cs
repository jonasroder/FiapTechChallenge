using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class GameRepository : EFRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
