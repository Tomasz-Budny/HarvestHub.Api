using HarvestHub.Modules.Users.Dal.Entity;

namespace HarvestHub.Modules.Users.Dal.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
