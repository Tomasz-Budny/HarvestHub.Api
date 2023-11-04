using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Entities;
using HarvestHub.Modules.Fields.Core.Owners.Aggregates;
using HarvestHub.Modules.Fields.Infrastructure.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance
{
    internal class FieldsDbContext : DbContext
    {
        public FieldsDbContext(DbContextOptions<FieldsDbContext> options) : base(options)
        {
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<CultivationHistory> History { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(schema: "fields");

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
