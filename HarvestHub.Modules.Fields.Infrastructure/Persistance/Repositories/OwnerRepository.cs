using HarvestHub.Modules.Fields.Core.Owners.Aggregates;
using HarvestHub.Modules.Fields.Core.Owners.Repositories;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Repositories
{
    internal class OwnerRepository : IOwnerRepository
    {
        private readonly FieldsDbContext _dbContext;
        private readonly DbSet<Owner> _owners;

        public OwnerRepository(FieldsDbContext dbContext)
        {
            _dbContext = dbContext;
            _owners = dbContext.Owners;
        }
        public async Task<Owner?> GetAsync(OwnerId ownerId)
         => await _owners
            .SingleOrDefaultAsync(x => x.Id == ownerId);

        public async Task UpdateAsync(Owner field)
        {
            _owners.Update(field);
            await _dbContext.SaveChangesAsync();
        }
    }
}
