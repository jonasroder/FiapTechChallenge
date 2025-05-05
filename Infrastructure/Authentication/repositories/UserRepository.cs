using Core.Authentication.Entities;
using Core.Authentication.Repositories;
using Infrastructure.SharedKernel.repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Authentication.repositories
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByUsernameAsync(string username)
          => _dbSet.FirstOrDefault(e => e.Email.Value == username);

        public async Task<bool> Exists(string email)
            => await _dbSet.AnyAsync(e => e.Email.Value == email);
    }
}
