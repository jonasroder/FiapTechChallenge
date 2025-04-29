using Core.Exceptions;
using System.Text.RegularExpressions;

namespace Core.ValueObjects
{
    public sealed class Email
    {
        public string Value { get; }
        public Email(string value)
        {
            if (!Regex.IsMatch(value, @"^[\w\.\-]+@[\w\-]+\.[\w\-\.]+$"))
                throw new DomainException("Formato de e-mail inválido.");
            Value = value;
        }
    }
}
