using HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Queries
{
    public record GetAllHistoryRecordsByFieldIdQuery(Guid FieldId, Guid OwnerId) : IQuery<IEnumerable<HarvestHistoryRecordDto>>;
}
