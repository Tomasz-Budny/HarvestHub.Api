using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Users.Core.Exceptions
{
    internal class UserPasswordResetTokenExpiresException : HarvestHubException
    {
        public UserPasswordResetTokenExpiresException() : base("User password reset token has expired!")
        {
        }
    }
}
