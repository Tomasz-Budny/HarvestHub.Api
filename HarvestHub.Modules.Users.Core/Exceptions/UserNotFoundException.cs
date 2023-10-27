using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Users.Core.Exceptions
{
    internal class UserNotFoundException : HarvestHubException
    {
        public UserNotFoundException() : base($"User was not found!")
        {
        }
    }
}
