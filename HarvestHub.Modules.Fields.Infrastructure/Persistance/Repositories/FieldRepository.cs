using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Repositories
{
    internal class FieldRepository : IFieldRepository
    {
        private readonly FieldsDbContext _dbContext;
        private readonly DbSet<Field> _fields;

        public FieldRepository(FieldsDbContext dbContext)
        {
            _dbContext = dbContext;
            _fields = dbContext.Fields;
        }

        public async Task AddAsync(Field field)
        {
            await _fields.AddAsync(field);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Field field)
        {
            _fields.Remove(field);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Field field)
        {
            _fields.Update(field);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Field?> GetAsync(FieldId fieldId, OwnerId ownerId)
            => await _fields
             .Include(x => x.Vertices.OrderBy(x => x.Order))
             .SingleOrDefaultAsync(x => x.Id == fieldId && x.OwnerId == ownerId);

    }
}
