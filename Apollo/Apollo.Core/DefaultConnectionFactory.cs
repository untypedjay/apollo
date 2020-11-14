using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Core
{
    public class DefaultConnectionFactory : IConnectionFactory
    {
        private readonly DbProviderFactory dbProviderFactory;

        public static IConnectionFactory FromConfiguration(IConfiguration config, string connectionStringConfigName)
        {
            var connectionConfig = config.GetSection("ConnectionStrings").GetSection(connectionStringConfigName);
            string connectionString = connectionConfig["ConnectionString"];
            string providerName = connectionConfig["ProviderName"];

            return new DefaultConnectionFactory(connectionString, providerName);
        }

        public DefaultConnectionFactory(string connectionString, string providerName)
        {
            this.ConnectionString = connectionString;
            this.ProviderName = providerName;
            this.dbProviderFactory = DbUtil.GetDbProviderFactory(providerName);
        }

        public string ConnectionString { get; }

        public string ProviderName { get; }

        public async Task<DbConnection> CreateConnectionAsync()
        {
            var connection = dbProviderFactory.CreateConnection();
            connection.ConnectionString = this.ConnectionString;
            await connection.OpenAsync();
            return connection;
        }
    }
}
