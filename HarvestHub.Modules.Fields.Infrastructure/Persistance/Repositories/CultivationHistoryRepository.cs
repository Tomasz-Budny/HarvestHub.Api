using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Repositories
{
    internal class CultivationHistoryRepository : ICultivationHistoryRepository
    {
        private readonly HistoryDbContext _dbContext;
        private readonly DbSet<CultivationHistory> _history;

        public CultivationHistoryRepository(HistoryDbContext dbContext)
        {
            _dbContext = dbContext;
            _history = dbContext.History;
        }
        public async Task<CultivationHistory?> GetAsync(CultivationHistoryId historyId, OwnerId ownerId, CancellationToken cancellationToken)
            => await _history
                .Include(x => x.History)
                .SingleOrDefaultAsync(x => x.Id == historyId && x.OwnerId == ownerId, cancellationToken);
    }
}
