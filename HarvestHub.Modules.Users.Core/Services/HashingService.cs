using System.Security.Cryptography;
using System.Text;

namespace HarvestHub.Modules.Users.Core.Services
{
    internal class HashingService : IHashingService
    {
        public (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();

            var passwordSalt = hmac.Key;
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (passwordHash, passwordSalt);
        }
    }
}
