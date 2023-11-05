using HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Queries
{
    public record GetHarvestHistoryRecordsQuery(Guid CultivationHistoryId, Guid OwnerId) : IQuery<IEnumerable<HarvestHistoryRecordDto>>;
}
