namespace Apollo.Core.Daos
{
    public class MSSQLReservedSeatDao : ReservedSeatDao
    {
        public MSSQLReservedSeatDao(IConnectionFactory connectionFactory) : base(connectionFactory) { }
    }
}
