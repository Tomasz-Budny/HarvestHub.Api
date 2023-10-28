using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Users.Core.Exceptions
{
    internal class UserPasswordInvalidException : HarvestHubException
    {
        public UserPasswordInvalidException() : base("Provided user password is invalid!")
        {
        }
    }
}
