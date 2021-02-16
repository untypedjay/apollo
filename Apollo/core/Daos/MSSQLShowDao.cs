namespace Apollo.Core.Daos
{
    public class MSSQLShowDao : ShowDao
    {
        public MSSQLShowDao(IConnectionFactory connectionFactory) : base(connectionFactory) { }
    }
}
