using Microsoft.Extensions.Configuration;
using System;
namespace Persistence
{
    public class ConnectionStringConfiguration
    {
        public static ConnectionSettings ConnectionSettings
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI"));
                configurationManager.AddJsonFile("appsettings.json");

                ConnectionSettings returnType = new(configurationManager, configurationManager.GetConnectionString("TobetoPlatformConnectionString"));

                return returnType;
            }
        }
    }

    public class ConnectionSettings
    {
        public ConfigurationManager ConfigurationManager;
        public string ConnectionString;

        public ConnectionSettings(ConfigurationManager configurationManager, string connectionString)
        {
            ConfigurationManager = configurationManager;
            ConnectionString = connectionString;
        }
    }
}

