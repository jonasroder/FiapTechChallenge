using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserResponseDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public AddressResponseDto Address { get; init; }
        public UserRole Role { get; init; }
    }
}
