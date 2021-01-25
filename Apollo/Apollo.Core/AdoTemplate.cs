using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, RowMapperAsync<T> rowMapperAsync, params QueryParameter[] parameters)
        {
            using (DbConnection connection = await connectionFactory.CreateConnectionAsync())
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;

                AddParameters(command, parameters);

                var items = new List<T>();
                T currentResult;
                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        currentResult = await rowMapperAsync(reader);
                        items.Add(currentResult);
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

        public async Task<T> QuerySingleAsync<T>(string sql, RowMapper<T> rowMapper, params QueryParameter[] parameters)
        {
            return (await QueryAsync(sql, rowMapper, parameters)).SingleOrDefault();
        }

        public async Task<T> QuerySingleAsync<T>(string sql, RowMapperAsync<T> rowMapperAsync, params QueryParameter[] parameters)
        {
            return (await QueryAsync(sql, rowMapperAsync, parameters)).SingleOrDefault();
        }

        public async Task<int> ExecuteAsync(string sql, params QueryParameter[] parameters)
        {
            using (DbConnection connection = await connectionFactory.CreateConnectionAsync())
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;
                AddParameters(command, parameters);
                try
                {
                    return await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    return 0;
                }
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
