using System.Data;

namespace Apollo.Core
{
    public class Delegates
    {
        public delegate T RowMapper<T>(IDataRecord row);
    }
}
