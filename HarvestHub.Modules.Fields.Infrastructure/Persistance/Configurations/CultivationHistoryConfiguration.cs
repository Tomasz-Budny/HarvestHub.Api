using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Configurations
{
    internal class CultivationHistoryConfiguration : IEntityTypeConfiguration<CultivationHistory>
    {
        public void Configure(EntityTypeBuilder<CultivationHistory> builder)
        {
            builder.ToTable("Fields");

            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));
        }
    }
}
