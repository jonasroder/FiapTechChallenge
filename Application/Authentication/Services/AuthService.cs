using Application.Authentication.Contracts;
using Application.DTOs.Auth;
using Application.SharedKernel.Common;
using Core.Authentication.Repositories;
using Infrastructure.SharedKernel.Logger;
using Infrastructure.SharedKernel.Security;

namespace Application.Authentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly BaseLogger<AuthService> _logger;

        public AuthService(IUserRepository userRepo, IJwtTokenGenerator tokenGenerator, BaseLogger<AuthService> logger)
        {
            _userRepo = userRepo;
            _tokenGenerator = tokenGenerator;
            _logger = logger;
        }

        public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request)
        {
            ResultLoggerContext.Set(_logger);

            _logger.LogInformation($"Iniciando processo de login. Email: {request.Username}");

            var user = await _userRepo.GetByUsernameAsync(request.Username);

            if (user is null)
                return Result<LoginResponse>.Unauthorized<AuthService>("Usuário ou senha inválidos.", "INVALID_USERNAME");

            if (!user.Password.Verify(request.Password))
                return Result<LoginResponse>.Forbidden<AuthService>("Senha incorreta.", "INVALID_PASSWORD");

            try
            {
                var (token, expires) = _tokenGenerator.Generate(user);

                return Result<LoginResponse>.Success<AuthService>(
                    new LoginResponse(token, expires),
                    $"Login realizado com sucesso. UserId: {user.Id}"
                );
            }
            catch (Exception ex)
            {
                return Result<LoginResponse>.InternalError<AuthService>($"Erro ao gerar token: {ex.Message}");
            }
        }

    }

}

