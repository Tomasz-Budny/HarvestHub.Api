using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Users.Core.Exceptions
{
    internal class UserEmailInvalidException : HarvestHubException
    {
        public UserEmailInvalidException(string email) : base($"Provided email: {email} is invalid!")
        {
        }
    }
}
