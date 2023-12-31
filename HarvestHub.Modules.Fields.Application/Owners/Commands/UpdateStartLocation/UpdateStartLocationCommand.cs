using HarvestHub.Modules.Fields.Application.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Owners.Commands.UpdateStartLocation
{
    public record UpdateStartLocationCommand (
        Guid OwnerId,
        PointDto Point
    ) : ICommand;
}
