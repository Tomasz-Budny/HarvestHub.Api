using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance
{
    internal class FieldsDbContext : DbContext
    {
        public FieldsDbContext(DbContextOptions<FieldsDbContext> options) : base(options)
        {
        }

        public DbSet<Field> Fields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(schema: "fields");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
