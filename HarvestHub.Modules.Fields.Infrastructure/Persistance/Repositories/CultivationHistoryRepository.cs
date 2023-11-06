using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Repositories
{
    internal class CultivationHistoryRepository : ICultivationHistoryRepository
    {
        private readonly FieldsDbContext _dbContext;
        private readonly DbSet<CultivationHistory> _history;

        public CultivationHistoryRepository(FieldsDbContext dbContext)
        {
            _dbContext = dbContext;
            _history = dbContext.History;
        }
        public async Task<CultivationHistory?> GetAsync(CultivationHistoryId historyId, CancellationToken cancellationToken)
            => await _history
                .Include(x => x.History)
                .SingleOrDefaultAsync(x => x.Id == historyId, cancellationToken);

        public async Task UpdateAsync(CultivationHistory cultivationHistory, CancellationToken cancellationToken)
        {
            _history.Update(cultivationHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        
    }
}
