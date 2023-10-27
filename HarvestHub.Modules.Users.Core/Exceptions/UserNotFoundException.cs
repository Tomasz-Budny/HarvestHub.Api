using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Users.Core.Exceptions
{
    internal class UserNotFoundException : HarvestHubException
    {
        public UserNotFoundException(string email) : base($"User with provided email: {email} was not found!")
        {
        }
    }
}
