using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Entities;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Configurations
{
    internal class CultivationHistoryConfiguration : IEntityTypeConfiguration<CultivationHistory>, IEntityTypeConfiguration<HistoryRecord>
    {
        public void Configure(EntityTypeBuilder<CultivationHistory> builder)
        {
            builder.ToTable("Fields");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Id, x.OwnerId }).IsUnique();

            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.OwnerId)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.HasMany(x => x.History).WithOne().HasForeignKey("FieldId");

        }

        public void Configure(EntityTypeBuilder<HistoryRecord> builder)
        {
            builder.ToTable("CultivationHistory");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property<CultivationHistoryId>("FieldId")
                .HasConversion(x => x.Value, x => new(x));

            builder
                .HasDiscriminator<string>("Type")
                .HasValue<HarvestHistoryRecord>("harvest")
                .HasValue<FertilizationHistoryRecord>("fertilization");
        }
    }
}
