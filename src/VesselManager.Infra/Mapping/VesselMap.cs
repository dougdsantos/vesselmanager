using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VesselManager.Domain.Entities;

namespace VesselManager.Infra.Mapping
{
    public class VesselMap : IEntityTypeConfiguration<Vessel>
    {
        public void Configure(EntityTypeBuilder<Vessel> builder)
        {
            builder.ToTable("Vessels");

            builder.HasKey(v => v.Id);

            builder.HasIndex(v => v.code)
                   .IsUnique();

            builder.HasMany(v => v.equipaments)
                .WithOne();
        }
    }
}
