using Microsoft.EntityFrameworkCore;
using VesselManager.Domain.Entities;

namespace VesselManager.Infra.Context
{
    public class BdContext : DbContext
    {
        public DbSet<Vessel> vessels { get; set; }
        public DbSet<Equipament> equipaments { get; set; }

        public BdContext(DbContextOptions<BdContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
