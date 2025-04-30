using Application.Authentication.DTOs;
using Application.Authentication.Interfaces;
using Core.Authentication.Entities;
using Core.Authentication.Repositories;
using Core.Authentication.ValueObjects;
using Infrastructure.SharedKernel.Logger;

namespace Application.Authentication.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepo;
        private readonly BaseLogger<UserAppService> _logger;

        public UserAppService(BaseLogger<UserAppService> logger, IUserRepository userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        public async Task<int> RegisterAsync(UserInput dto)
        {
            _logger.LogInformation($"Iniciando registro de novo usuário. Email: {dto.Email}");

            var emailVo = new Email(dto.Email);
            var passwordVo = Password.Create(dto.Password);
            var addressVo = new Address
            {
                Street = dto.Address.Street,
                City = dto.Address.City,
                State = dto.Address.State,
                ZipCode = dto.Address.ZipCode,
                Country = dto.Address.Country
            };

            var user = new User
            {
                Name = dto.Name,
                DateOfBirth = dto.DateOfBirth,
                Email = emailVo,
                Phone = dto.Phone,
                Address = addressVo,
                Password = passwordVo,
                Role = dto.Role
            };

            _userRepo.Add(user);
            _logger.LogInformation($"Usuário registrado com sucesso. UserId: {user.Id}");

            return user.Id;
        }

        public async Task<UserResponseDto> GetById(int id)
        {
            _logger.LogInformation($"Buscando usuário por Id: {id}");

            var user = _userRepo.GetById(id);
            if (user == null)
            {
                _logger.LogWarning($"Usuário não encontrado. Id: {id}");
                return null;
            }

            var result = new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email.Value,
                Phone = user.Phone,
                Role = user.Role,
                Address = new AddressResponseDto
                {
                    Street = user.Address.Street,
                    City = user.Address.City,
                    State = user.Address.State,
                    ZipCode = user.Address.ZipCode,
                    Country = user.Address.Country
                }
            };

            _logger.LogInformation($"Usuário encontrado e mapeado para DTO. Id: {id}");
            return result;           
        }
    }
}
