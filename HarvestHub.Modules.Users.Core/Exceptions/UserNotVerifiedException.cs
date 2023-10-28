using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Users.Core.Exceptions
{
    internal class UserNotVerifiedException : HarvestHubException
    {
        public UserNotVerifiedException() : base("User has not been verified!")
        {
        }
    }
}
