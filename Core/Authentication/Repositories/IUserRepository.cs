using Core.Authentication.Entities;
using Core.SharedKernel.Repository;

namespace Core.Authentication.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
        Task<bool> Exists(string email);

    }
}
