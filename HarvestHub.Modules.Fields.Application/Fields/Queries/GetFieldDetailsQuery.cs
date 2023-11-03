using HarvestHub.Modules.Fields.Application.Fields.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Queries
{
    public record GetFieldDetailsQuery(Guid OwnerId, Guid FieldId) : IQuery<FieldDetailsDto>;
}
