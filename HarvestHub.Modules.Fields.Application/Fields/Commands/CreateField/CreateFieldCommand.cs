using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.CreateField
{
    internal record CreateFieldCommand(Guid FieldId, string Name) : ICommand;
}
