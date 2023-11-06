using HarvestHub.Modules.Fields.Application.CultivationHistories.Services;
using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Services
{
    internal class CultivationHistoryService : ICultivationHistoryService
    {
        private readonly FieldsDbContext _dbContext;
        private readonly DbSet<CultivationHistory> _history;

        public CultivationHistoryService(FieldsDbContext dbContext)
        {
            _dbContext = dbContext;
            _history = dbContext.History;
        }
        public async Task<CultivationHistory> GetByFieldId(Guid fieldId, Guid ownerId, CancellationToken cancellationToken)
        {
            var fieldExists = await _dbContext.Fields.AnyAsync(x => x.Id == new FieldId(fieldId) && x.OwnerId == new OwnerId(ownerId));

            if (!fieldExists)
            {
                throw new FieldNotFoundException(fieldId);
            }
            var cultivationhistory = await _history
            .Include(x => x.History)
                .SingleOrDefaultAsync(x => x.FieldId == new FieldId(fieldId), cancellationToken);

            if (cultivationhistory is null)
            {
                throw new CultivationHistoryNotFoundException(fieldId);
            }

            return cultivationhistory;
        }
    }
}
