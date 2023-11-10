using HarvestHub.Modules.Fields.Application.CultivationHistories.Services;
using HarvestHub.Modules.Fields.Core.CultivationHistories.Aggregates;
using HarvestHub.Modules.Fields.Core.CultivationHistories.Exceptions;
using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Modules.Fields.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Modules.CultivationHistories.Infrastructure.Persistance.Services
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

        public async Task<bool> ExistsByFieldId(Guid fieldId, CancellationToken cancellationToken)
         => await _history.AnyAsync(x => x.FieldId == new FieldId(fieldId), cancellationToken);
    }
}
