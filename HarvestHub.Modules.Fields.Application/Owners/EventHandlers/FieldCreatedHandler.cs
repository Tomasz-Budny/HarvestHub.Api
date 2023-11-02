using HarvestHub.Modules.Fields.Core.Owners.Exceptions;
using HarvestHub.Modules.Fields.Core.Owners.Repositories;
using HarvestHub.Modules.Fields.Shared.Events;
using HarvestHub.Shared.Events;

namespace HarvestHub.Modules.Fields.Application.Owners.EventHandlers
{
    internal sealed class FieldCreatedHandler : IEventHandler<FieldCreated>
    {
        private readonly IOwnerRepository _ownerRepository;

        public FieldCreatedHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task HandleAsync(FieldCreated @event, CancellationToken cancellationToken = default)
        {
            var owner = await _ownerRepository.GetAsync(@event.OwnerId);

            if (owner is null)
            {
                throw new OwnerNotFoundException(@event.OwnerId);
            }

            owner.AddField(@event.Area);

            await _ownerRepository.UpdateAsync(owner);
        }
    }
}
