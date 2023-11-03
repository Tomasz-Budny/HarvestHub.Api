using HarvestHub.Modules.Fields.Core.Fields.Primitives;

namespace HarvestHub.Modules.Fields.Application.Fields.Dtos
{
    public record PatchFieldDetailsRequest(
        string? Name = null,
        FieldClassStatus? Class = null,
        OwnershipStatus? OwnershipStatus = null,
        string? Color = null
    );
}
