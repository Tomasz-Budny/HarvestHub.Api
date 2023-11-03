using HarvestHub.Modules.Fields.Core.Fields.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Configurations
{
    internal class HarvestHistoryRecordConfiguration : IEntityTypeConfiguration<HarvestHistoryRecord>
    {
        public void Configure(EntityTypeBuilder<HarvestHistoryRecord> builder)
        {
            builder.Property(x => x.Amount)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.Humidity)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.CropType)
                .IsRequired();
        }
    }
}
