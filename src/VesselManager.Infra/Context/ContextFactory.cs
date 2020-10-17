using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VesselManager.Infra.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<BdContext>
    {
        public BdContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=:memory:;Version=3;New=True;";
            var optionsBuilder = new DbContextOptionsBuilder<BdContext>();
            optionsBuilder.UseSqlite(connectionString);
            return new BdContext(optionsBuilder.Options);
        }
    }
}
