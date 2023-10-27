using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Users.Core.Exceptions
{
    internal class UserAlreadyExistsException : HarvestHubException
    {
        public UserAlreadyExistsException(string email) : base($"User with provided email: {email} already exists!")
        {
        }
    }
}
