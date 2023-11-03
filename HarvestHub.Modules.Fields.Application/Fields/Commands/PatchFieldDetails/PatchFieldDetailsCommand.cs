using HarvestHub.Modules.Fields.Core.Fields.Primitives;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.PatchFieldDetails
{
    public record PatchFieldDetailsCommand(
        Guid FieldId, 
        Guid OwnerId, 
        string? Name,
        FieldClassStatus? Class,
        OwnershipStatus? OwnershipStatus,
        string? Color
    ) : ICommand;
}
