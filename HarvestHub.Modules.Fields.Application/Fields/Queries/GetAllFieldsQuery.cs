using HarvestHub.Modules.Fields.Application.Fields.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Queries
{
    public record GetAllFieldsQuery(Guid OwnerId) : IQuery<IEnumerable<FieldDto>>;
}
