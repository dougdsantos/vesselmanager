using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VesselManager.Domain.Entities;

namespace VesselManager.Infra.Mapping
{
    public class EquipamentMap : IEntityTypeConfiguration<Equipament>
    {
        public void Configure(EntityTypeBuilder<Equipament> builder)
        {
            builder.ToTable("Equipaments");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.code)
            .IsRequired();

            builder.Property(e => e.name)
            .IsRequired();

            builder.Property(e => e.location)
            .IsRequired();
        }
    }
}
