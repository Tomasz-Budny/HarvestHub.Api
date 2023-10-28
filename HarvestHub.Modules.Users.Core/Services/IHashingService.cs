namespace HarvestHub.Modules.Users.Core.Services
{
    internal interface IHashingService
    {
        (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password);
        bool ValidatePassword(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
