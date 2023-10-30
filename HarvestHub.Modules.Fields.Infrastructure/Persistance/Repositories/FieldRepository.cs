using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
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
    }
}
