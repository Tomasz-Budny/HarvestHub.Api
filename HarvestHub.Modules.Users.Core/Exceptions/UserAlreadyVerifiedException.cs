using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Users.Core.Exceptions
{
    internal class UserAlreadyVerifiedException : HarvestHubException
    {
        public UserAlreadyVerifiedException() : base("User was already verified!")
        {
        }
    }
}
