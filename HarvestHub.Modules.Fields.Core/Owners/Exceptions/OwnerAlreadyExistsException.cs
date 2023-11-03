using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Modules.Fields.Core.Owners.Exceptions
{
    public class OwnerAlreadyExistsException : HarvestHubException
    {
        public Guid OwnerId { get; }
        public OwnerAlreadyExistsException(Guid ownerId) : base($"Owner with provided id: {ownerId} already exists!")
        {
            OwnerId = ownerId;
        }
    }
}
