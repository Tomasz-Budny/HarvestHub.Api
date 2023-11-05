﻿using HarvestHub.Modules.Fields.Core.Fields.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Configurations
{
    internal class FertilizationHistoryRecordConfiguration : IEntityTypeConfiguration<FertilizationHistoryRecord>
    {
        public void Configure(EntityTypeBuilder<FertilizationHistoryRecord> builder)
        {
            builder.Property(x => x.Amount)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x))
                .HasColumnName("Amount");

            builder.Property(x => x.FertilizerType)
                .IsRequired();
        }
    }
}
