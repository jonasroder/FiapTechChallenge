using Application.DTOs;

namespace Application.Interfaces;
public interface IUserAppService
{
    Task<Guid> RegisterAsync(UserDto dto);
}