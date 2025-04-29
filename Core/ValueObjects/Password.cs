using Core.Exceptions;
using System.Security.Cryptography;

namespace Core.ValueObjects
{
    public sealed class Password
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        public string Hash { get; }
        private Password(string hash) => Hash = hash;
        public static Password Create(string plain)
        {
            if (plain.Length < 8)
                throw new DomainException("Senha deve ter ao menos 8 caracteres.");
            // gerar salt + hash PBKDF2...
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                plain, salt, 100_000, HashAlgorithmName.SHA256, HashSize);
            return new Password($"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}");
        }

        public bool Verify(string attempt)
        {
            var parts = Hash.Split('.');
            var salt = Convert.FromBase64String(parts[0]);
            var hash = Convert.FromBase64String(parts[1]);
            var attemptHash = Rfc2898DeriveBytes.Pbkdf2(
                attempt, salt, 100_000, HashAlgorithmName.SHA256, hash.Length);
            return CryptographicOperations.FixedTimeEquals(attemptHash, hash);
        }
    }
}
