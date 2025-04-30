using Core.Gaming.Entities;
using Core.Gaming.Repositories;
using Infrastructure.SharedKernel.repositories;

namespace Infrastructure.Gaming.repositories
{
    public class OwnershipRepository : EFRepository<Ownership>, IOwnershipRepository
    {
        public OwnershipRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
