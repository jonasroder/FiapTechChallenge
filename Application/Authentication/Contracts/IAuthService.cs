using Application.DTOs.Auth;
using Application.SharedKernel.Common;

namespace Application.Authentication.Contracts;

public interface IAuthService
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest request);
}
