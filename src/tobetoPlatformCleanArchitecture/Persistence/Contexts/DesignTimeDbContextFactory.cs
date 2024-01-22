using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persistence;
using Persistence.Contexts;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TobetoPlatformDbContext>
{
    public TobetoPlatformDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TobetoPlatformDbContext>();
        optionsBuilder.UseSqlServer(ConnectionStringConfiguration.ConnectionSettings.ConnectionString);

        return new TobetoPlatformDbContext(optionsBuilder.Options, ConnectionStringConfiguration.ConnectionSettings.ConfigurationManager);
    }
}
