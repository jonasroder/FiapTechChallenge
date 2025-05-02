using Application.DTOs.Auth;

namespace Application.Authentication.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
