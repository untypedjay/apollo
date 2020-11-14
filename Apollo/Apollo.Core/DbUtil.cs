using System;
using System.Data.Common;

namespace Apollo.Core
{
    public static class DbUtil
    {
        public static DbProviderFactory GetDbProviderFactory(string providerName)
        {
            switch (providerName)
            {
                case "Microsoft.Data.SqlClient": return Microsoft.Data.SqlClient.SqlClientFactory.Instance;
                case "System.Data.SqlClient": return System.Data.SqlClient.SqlClientFactory.Instance;
                case "MySql.Data.MySqlClient": return MySql.Data.MySqlClient.MySqlClientFactory.Instance;
                default: throw new ArgumentException("Invalid provider name \"{providerName}\"");
            }
        }
    }
}
