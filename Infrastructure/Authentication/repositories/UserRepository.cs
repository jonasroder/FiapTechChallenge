using Core.Authentication.Entities;
using Core.Authentication.Repositories;
using Infrastructure.SharedKernel.repositories;

namespace Infrastructure.Authentication.repositories
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByUsernameAsync(string username)
          => _dbSet.FirstOrDefault(e => e.Email.Value == username);
    }
}
