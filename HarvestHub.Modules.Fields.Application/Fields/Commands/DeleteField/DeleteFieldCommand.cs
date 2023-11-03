using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.DeleteField
{
    public record DeleteFieldCommand(
        Guid Id, 
        Guid OwnerId

    ) : ICommand;
}
