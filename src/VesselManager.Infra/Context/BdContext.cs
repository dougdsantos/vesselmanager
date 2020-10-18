using Microsoft.EntityFrameworkCore;
using VesselManager.Domain.Entities;
using VesselManager.Infra.Mapping;

namespace VesselManager.Infra.Context
{
    public class BdContext : DbContext
    {
        public DbSet<Vessel> vessels { get; set; }
        public DbSet<Equipment> equipaments { get; set; }

        public BdContext(DbContextOptions<BdContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vessel>(new VesselMap().Configure);
            modelBuilder.Entity<Equipment>(new EquipmentMap().Configure);
        }
    }
}
