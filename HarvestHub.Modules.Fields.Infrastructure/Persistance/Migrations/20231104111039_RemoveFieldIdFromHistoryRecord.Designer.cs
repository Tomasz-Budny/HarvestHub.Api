﻿// <auto-generated />
using System;
using HarvestHub.Modules.Fields.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(FieldsDbContext))]
    [Migration("20231104111039_RemoveFieldIdFromHistoryRecord")]
    partial class RemoveFieldIdFromHistoryRecord
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("fields")
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HarvestHub.Modules.Fields.Core.Fields.Aggregates.Field", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<string>("Center")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OwnershipStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id", "OwnerId")
                        .IsUnique();

                    b.ToTable("Fields", "fields");
                });

            modelBuilder.Entity("HarvestHub.Modules.Fields.Core.Fields.Entities.HistoryRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CultivationHistory", "fields");

                    b.HasDiscriminator<string>("Type").HasValue("HistoryRecord");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("HarvestHub.Modules.Fields.Core.Owners.Aggregates.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NumberOfFields")
                        .HasColumnType("bigint");

                    b.Property<string>("StartLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SumArea")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Owners", "fields");
                });

            modelBuilder.Entity("HarvestHub.Modules.Fields.Core.Fields.Entities.FertilizationHistoryRecord", b =>
                {
                    b.HasBaseType("HarvestHub.Modules.Fields.Core.Fields.Entities.HistoryRecord");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("FertilizerType")
                        .HasColumnType("int");

                    b.ToTable("CultivationHistory", "fields", t =>
                        {
                            t.Property("Amount")
                                .HasColumnName("FertilizationHistoryRecord_Amount");
                        });

                    b.HasDiscriminator().HasValue("fertilization");
                });

            modelBuilder.Entity("HarvestHub.Modules.Fields.Core.Fields.Entities.HarvestHistoryRecord", b =>
                {
                    b.HasBaseType("HarvestHub.Modules.Fields.Core.Fields.Entities.HistoryRecord");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CropType")
                        .HasColumnType("int");

                    b.Property<uint>("Humidity")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("harvest");
                });

            modelBuilder.Entity("HarvestHub.Modules.Fields.Core.Fields.Aggregates.Field", b =>
                {
                    b.OwnsMany("HarvestHub.Modules.Fields.Core.Fields.Entities.Vertex", "Vertices", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("FieldId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.Property<uint>("Order")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("FieldId", "Id")
                                .IsUnique();

                            b1.ToTable("Vertices", "fields");

                            b1.WithOwner()
                                .HasForeignKey("FieldId");
                        });

                    b.Navigation("Vertices");
                });
#pragma warning restore 612, 618
        }
    }
}
