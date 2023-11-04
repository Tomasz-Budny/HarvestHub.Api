using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Entities;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Modules.Fields.Infrastructure.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance
{
    internal class HistoryDbContext : DbContext
    {
        public HistoryDbContext(DbContextOptions<HistoryDbContext> options) : base(options)
        {
        }

        public DbSet<CultivationHistory> History { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(schema: "fields");

            modelBuilder.ApplyConfiguration<CultivationHistory>(new CultivationHistoryConfiguration());
            modelBuilder.ApplyConfiguration<HistoryRecord>(new CultivationHistoryConfiguration());

            modelBuilder.ApplyConfiguration(new FertilizationHistoryRecordConfiguration());
            modelBuilder.ApplyConfiguration(new HarvestHistoryRecordConfiguration());
        }
    }
}
