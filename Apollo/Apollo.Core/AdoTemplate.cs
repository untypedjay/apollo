using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using static Apollo.Core.Delegates;

namespace Apollo.Core
{
    public class AdoTemplate
    {
        private readonly IConnectionFactory connectionFactory;

        public AdoTemplate(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, RowMapper<T> rowMapper, params QueryParameter[] parameters)
        {
            using (DbConnection connection = await connectionFactory.CreateConnectionAsync())
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;

                AddParameters(command, parameters);

                var items = new List<T>();
                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        items.Add(rowMapper(reader));
                    }
                }

                return items;
            }
        }

        private void AddParameters(DbCommand command, QueryParameter[] parameters)
        {
            foreach (var p in parameters)
            {
                DbParameter dbParam = command.CreateParameter();
                dbParam.ParameterName = p.Name;
                dbParam.Value = p.Value;
                command.Parameters.Add(dbParam);
            }
        }

        public async Task<int> ExecuteAsync(string sql, params QueryParameter[] parameters)
        {
            using (DbConnection connection = await connectionFactory.CreateConnectionAsync())
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;
                AddParameters(command, parameters);

                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, params QueryParameter[] parameters)
        {
            using (DbConnection connection = await connectionFactory.CreateConnectionAsync())
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;
                AddParameters(command, parameters);

                return (T)(await command.ExecuteScalarAsync());
            }
        }
    }
}
