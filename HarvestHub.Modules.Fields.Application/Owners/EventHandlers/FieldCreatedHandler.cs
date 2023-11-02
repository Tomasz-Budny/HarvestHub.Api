using HarvestHub.Modules.Fields.Shared.Events;
using HarvestHub.Shared.Events;

namespace HarvestHub.Modules.Fields.Application.Owners.EventHandlers
{
    internal sealed class FieldCreatedHandler : IEventHandler<FieldCreated>
    {
        public Task HandleAsync(FieldCreated @event, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
