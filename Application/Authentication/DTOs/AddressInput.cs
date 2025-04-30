using System.ComponentModel.DataAnnotations;

namespace Application.Authentication.DTOs
{
    public class AddressInput : IValidatableObject
    {
        [Required] public string Street { get; set; }
        [Required] public string City { get; set; }
        [Required][StringLength(2)] public string State { get; set; }
        [Required] public string ZipCode { get; set; }
        [Required] public string Country { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext ctx)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(ZipCode, @"^\d{5}-\d{3}$"))
                yield return new ValidationResult("CEP inválido.", new[] { nameof(ZipCode) });
        }
    }
}