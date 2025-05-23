﻿using Core.Authentication.Enums;
using Core.Authentication.ValueObjects;
using Core.SharedKernel.Entity;

namespace Core.Authentication.Entities
{
    public class User : EntityBase
    {
        public required string Name { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required Email Email { get; set; }
        public required string Phone { get; set; }
        public required Address Address { get; set; }
        public required Password Password { get; set; }
        public required UserRole Role { get; set; }
    }
}
