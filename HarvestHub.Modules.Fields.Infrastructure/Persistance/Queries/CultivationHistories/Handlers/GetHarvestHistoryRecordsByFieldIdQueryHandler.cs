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
    internal class GetHarvestHistoryRecordsByFieldIdQueryHandler : IQueryHandler<GetHarvestHistoryRecordsByFieldIdQuery, IEnumerable<HarvestHistoryRecordDto>>
    {
        private readonly DbSet<CultivationHistory> _history;
        private readonly FieldsDbContext _dbContext;

        public GetHarvestHistoryRecordsByFieldIdQueryHandler(FieldsDbContext dbContext)
        {
            _history = dbContext.History;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<HarvestHistoryRecordDto>> Handle(GetHarvestHistoryRecordsByFieldIdQuery request, CancellationToken cancellationToken)
        {
            var (historyId, ownerId) = request;

            var fieldExists = await _dbContext.Fields.AnyAsync(x => x.Id == new FieldId(historyId) && x.OwnerId == new OwnerId(ownerId));

            if(!fieldExists)
            {
                throw new FieldNotFoundException(historyId);
            }

            var Cultivationhistory = await _history
                .Include(x => x.History)
                .SingleOrDefaultAsync(x => x.FieldId == new FieldId(historyId), cancellationToken);

            if (Cultivationhistory is null)
            {
                throw new CultivationHistoryNotFoundException(historyId);
            }

            var harvestHistoryRecords = Cultivationhistory.History.OfType<HarvestHistoryRecord>();

            return harvestHistoryRecords.Select(x => CultivationHistoryMapper.MapToHarvestHistoryRecordDto(x));
        }
    }
}
