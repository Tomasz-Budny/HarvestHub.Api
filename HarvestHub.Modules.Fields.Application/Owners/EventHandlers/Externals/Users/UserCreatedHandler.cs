using HarvestHub.Modules.Fields.Core.Owners.Aggregates;
using HarvestHub.Modules.Fields.Core.Owners.Exceptions;
using HarvestHub.Modules.Fields.Core.Owners.Repositories;
using HarvestHub.Modules.Users.Shared.Events;
using HarvestHub.Shared.Events;

namespace HarvestHub.Modules.Fields.Application.Owners.EventHandlers.Externals.Users
{
    internal class UserCreatedHandler : IEventHandler<UserCreated>
    {
        private readonly IOwnerRepository _ownerRepository;

        public UserCreatedHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public async Task HandleAsync(UserCreated @event, CancellationToken cancellationToken = default)
        {
            var (id, firstName, lastName, _, _) = @event;

            if(await _ownerRepository.GetAsync(@event.Id) is not null)
            {
                throw new OwnerAlreadyExistsException(@event.Id);
            }

            var owner = new Owner(id, firstName, lastName, null, null, 0, 0);

            await _ownerRepository.AddAsync(owner);
        }
    }
}
