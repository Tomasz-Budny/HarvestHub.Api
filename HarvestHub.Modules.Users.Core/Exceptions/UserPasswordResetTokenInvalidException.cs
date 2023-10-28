using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Users.Core.Exceptions
{
    internal class UserPasswordResetTokenInvalidException : HarvestHubException
    {
        public UserPasswordResetTokenInvalidException() : base("Provided password reset token does not match with user token!")
        {
        }
    }
}
