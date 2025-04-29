using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class OwnershipRepository : EFRepository<Ownership>, IOwnershipRepository
    {
        public OwnershipRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
