namespace HarvestHub.Modules.Users.Dal.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId);
    }
}
