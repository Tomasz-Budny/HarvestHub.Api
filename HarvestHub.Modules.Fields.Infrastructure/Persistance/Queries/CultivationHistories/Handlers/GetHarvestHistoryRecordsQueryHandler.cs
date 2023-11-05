using HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Modules.Fields.Application.CultivationHistories.Mappers;
using HarvestHub.Modules.Fields.Application.CultivationHistories.Queries;
using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Entities;
using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Queries.CultivationHistories.Handlers
{
    internal class GetHarvestHistoryRecordsQueryHandler : IQueryHandler<GetHarvestHistoryRecordsQuery, IEnumerable<HarvestHistoryRecordDto>>
    {
        private readonly DbSet<CultivationHistory> _history;

        public GetHarvestHistoryRecordsQueryHandler(FieldsDbContext dbContext)
        {
            _history = dbContext.History;
        }

        public async Task<IEnumerable<HarvestHistoryRecordDto>> Handle(GetHarvestHistoryRecordsQuery request, CancellationToken cancellationToken)
        {
            var (historyId, ownerId) = request;

            var Cultivationhistory = await _history
                .Include(x => x.History)
                .SingleOrDefaultAsync(x => x.Id == new CultivationHistoryId(historyId) && x.OwnerId == new OwnerId(ownerId), cancellationToken);

            if (Cultivationhistory is null)
            {
                throw new CultivationHistoryNotFoundException(historyId);
            }

            var harvestHistoryRecords = Cultivationhistory.History.OfType<HarvestHistoryRecord>();

            return harvestHistoryRecords.Select(x => CultivationHistoryMapper.MapToHarvestHistoryRecordDto(x));
        }
    }
}
