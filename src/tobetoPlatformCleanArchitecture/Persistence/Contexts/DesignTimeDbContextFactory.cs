using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persistence;
using Persistence.Contexts;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BaseDbContext>
{
    public BaseDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BaseDbContext>();
        optionsBuilder.UseSqlServer(ConnectionStringConfiguration.ConnectionSettings.ConnectionString);

        return new BaseDbContext(optionsBuilder.Options, ConnectionStringConfiguration.ConnectionSettings.ConfigurationManager);
    }
}
