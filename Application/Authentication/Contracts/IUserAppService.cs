using Application.Authentication.DTOs;
using Application.SharedKernel.Common;

namespace Application.Authentication.Contracts
{
    public interface IUserAppService
    {
        Task<Result<UserResponseDto>> RegisterAsync(UserInput dto);
        Task<Result<UserResponseDto>> GetById(int id);
    }
}
