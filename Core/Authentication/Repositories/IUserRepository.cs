using Core.Authentication.Entities;
using Core.SharedKernel.Repository;

namespace Core.Authentication.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
