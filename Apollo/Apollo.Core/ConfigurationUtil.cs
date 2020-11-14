using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Apollo.Core
{
    public static class ConfigurationUtil
    {
        private static IConfiguration configuration = null;

        public static IConfiguration GetConfiguration(string basePath) =>
            configuration = configuration ?? new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

        public static (string connectionString, string providerName) GetConnectionParameters(string configName, string basePath)
        {
            var connectionConfig = GetConfiguration(basePath).GetSection("ConnectionStrings").GetSection(configName);
            return (connectionConfig["ConnectionString"], connectionConfig["ProviderName"]);
        }
    }
}
