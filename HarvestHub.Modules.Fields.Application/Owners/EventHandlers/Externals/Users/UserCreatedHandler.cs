using HarvestHub.Modules.Users.Shared.Events;
using HarvestHub.Shared.Events;

namespace HarvestHub.Modules.Fields.Application.Owners.EventHandlers.Externals.Users
{
    internal class UserCreatedHandler : IEventHandler<UserCreated>
    {
        public Task HandleAsync(UserCreated @event, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
