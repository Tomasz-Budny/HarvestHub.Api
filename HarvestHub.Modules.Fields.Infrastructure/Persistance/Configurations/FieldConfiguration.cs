using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.Entities;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Configurations
{
    internal class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.ToTable("Fields");
            builder.HasIndex(x => new { x.Id, x.OwnerId }).IsUnique();
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            var pointConverter = new ValueConverter<Point, string>(x => x.ToString(), x => Point.Create(x));
            builder.Property(x => x.Center)
                .IsRequired()
                .HasConversion(pointConverter);

            builder.Property(x => x.Area)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            builder.Property(x => x.Area)
                .IsRequired()
                .HasConversion(x => x.Value, x => new(x));

            var addressConverter = new ValueConverter<Address, string>(x => x.ToString(), x => Address.Create(x));
            builder.Property(x => x.Address)
                .IsRequired()
                .HasConversion(addressConverter);

            builder.Property(x => x.Color)
                .IsRequired()
                .HasMaxLength(7)
                .HasConversion(x => x.Value, x => new(x));

            ConfigureVerticesTable(builder);
        }

        private void ConfigureVerticesTable(EntityTypeBuilder<Field> builder)
        {
            builder.OwnsMany(typeof(Vertex), "_vertices", vb =>
            {
                vb.ToTable("Vertices");
                vb.HasIndex("FieldId", "Order").IsUnique();
                vb.WithOwner().HasForeignKey("FieldId");
            });
        }
    }
}
