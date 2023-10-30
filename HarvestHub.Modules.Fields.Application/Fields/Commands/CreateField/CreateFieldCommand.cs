using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.CreateField
{
    public record CreateFieldCommand(Guid FieldId, string Name) : ICommand;
}
