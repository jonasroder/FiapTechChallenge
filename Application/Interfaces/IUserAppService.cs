using Application.DTOs;

namespace Application.Interfaces;
public interface IUserAppService
{
    Task<int> RegisterAsync(UserInput dto);

    Task<UserResponseDto> GetById(int id);
}