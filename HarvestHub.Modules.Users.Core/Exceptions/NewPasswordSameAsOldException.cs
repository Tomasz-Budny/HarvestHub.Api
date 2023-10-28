using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Users.Core.Exceptions
{
    internal class NewPasswordSameAsOldException : HarvestHubException
    {
        public NewPasswordSameAsOldException() : base("New password is the same as the old one!")
        {
        }
    }
}
