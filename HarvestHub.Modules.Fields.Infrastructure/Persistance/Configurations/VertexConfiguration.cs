using HarvestHub.Modules.Fields.Core.Fields.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Configurations
{
    internal class VertexConfiguration : IEntityTypeConfiguration<Vertex>
    {
        public void Configure(EntityTypeBuilder<Vertex> builder)
        {
            builder.ToTable("Vertices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.Order)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.Latitude)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.Longitude)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));
        }
    }
}
