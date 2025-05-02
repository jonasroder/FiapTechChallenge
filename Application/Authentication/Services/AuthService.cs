using Application.Authentication.Interfaces;
using Application.DTOs.Auth;
using Core.Authentication.Repositories;
using Infrastructure.SharedKernel.Security;

namespace Application.Authentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public AuthService(IUserRepository userRepo, IJwtTokenGenerator tokenGenerator)
        {
            _userRepo = userRepo;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepo.GetByUsernameAsync(request.Username)
                       ?? throw new UnauthorizedAccessException("Usuário ou senha inválidos.");

            if (!user.Password.Verify(request.Password))
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");

            var (token, expires) = _tokenGenerator.Generate(user);
            return new LoginResponse(token, expires);
        }
    }
}
