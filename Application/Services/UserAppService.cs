using Application.DTOs;
using Application.Interfaces;
using Core.Repository;

namespace Application.Services;
public class UserAppService : IUserAppService
{
    private readonly IUserRepository _userRepo;

    public UserAppService(IUserRepository userRepo) =>
        _userRepo = userRepo;

    public async Task<Guid> RegisterAsync(UserDto dto)
    {
        return await Task.FromResult(Guid.NewGuid());
    }
}