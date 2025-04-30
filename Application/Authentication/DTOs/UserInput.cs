using Core.Authentication.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Authentication.DTOs
{
    public class UserInput : IValidatableObject
    {
        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required]
        public AddressInput Address { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext ctx)
        {
            if (DateOfBirth > DateTime.Today)
                yield return new ValidationResult(
                    "Data de nascimento deve ser no passado.",
                    new[] { nameof(DateOfBirth) });
            yield break;
        }
    }
}