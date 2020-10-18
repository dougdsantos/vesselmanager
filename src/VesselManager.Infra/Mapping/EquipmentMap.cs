using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VesselManager.Domain.Entities;

namespace VesselManager.Infra.Mapping
{
    public class EquipmentMap : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipments");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.vessel)
            .WithMany();

            builder.Property(e => e.code)
            .IsRequired();

            builder.Property(e => e.name)
            .IsRequired();

            builder.Property(e => e.location)
            .IsRequired();
        }
    }
}
