namespace HarvestHub.Modules.Users.Dal.Authentication.Options
{
    public class UsersOptions
    {
        public const string SectionName = "users";
        public TimeSpan PasswordResetTokenExpiry { get; init; }
    }
}
