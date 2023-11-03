using HarvestHub.Modules.Fields.Core.Fields.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Configurations
{
    internal class HistoryRecordConfiguration : IEntityTypeConfiguration<HistoryRecord>
    {
        public void Configure(EntityTypeBuilder<HistoryRecord> builder)
        {
            builder.ToTable("CultivationHistory");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property(x => x.FieldId)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder
                .HasDiscriminator<string>("Type")
                .HasValue<HarvestHistoryRecord>("harvest")
                .HasValue<FertilizationHistoryRecord>("fertilization");
        }
    }
}
