using System.Data;
using System.Threading.Tasks;

namespace Apollo.Core
{
    public class Delegates
    {
        public delegate T RowMapper<T>(IDataRecord row);
        public delegate Task<T> RowMapperAsync<T>(IDataRecord row);
    }
}
