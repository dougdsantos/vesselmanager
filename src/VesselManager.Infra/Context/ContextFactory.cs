using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VesselManager.Infra.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<BdContext>
    {
        public BdContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=.\\SQLEXPRESS2017;Initial Catalog=vesselDb;Integrated Security=True;";
            var optionsBuilder = new DbContextOptionsBuilder<BdContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new BdContext(optionsBuilder.Options);
        }
    }
}
