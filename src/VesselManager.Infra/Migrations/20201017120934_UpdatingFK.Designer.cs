﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VesselManager.Infra.Context;

namespace VesselManager.Infra.Migrations
{
    [DbContext(typeof(BdContext))]
    [Migration("20201017120934_UpdatingFK")]
    partial class UpdatingFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("VesselManager.Domain.Entities.Equipament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<Guid?>("vesselId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("vesselId");

                    b.ToTable("Equipaments");
                });

            modelBuilder.Entity("VesselManager.Domain.Entities.Vessel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("code")
                        .IsUnique();

                    b.ToTable("Vessels");
                });

            modelBuilder.Entity("VesselManager.Domain.Entities.Equipament", b =>
                {
                    b.HasOne("VesselManager.Domain.Entities.Vessel", "vessel")
                        .WithMany("equipaments")
                        .HasForeignKey("vesselId");

                    b.Navigation("vessel");
                });

            modelBuilder.Entity("VesselManager.Domain.Entities.Vessel", b =>
                {
                    b.Navigation("equipaments");
                });
#pragma warning restore 612, 618
        }
    }
}
