using Application.Authentication.DTOs;

namespace Application.Authentication.Interfaces;
public interface IUserAppService
{
    Task<int> RegisterAsync(UserInput dto);

    Task<UserResponseDto> GetById(int id);
}