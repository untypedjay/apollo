namespace Apollo.Core.Daos
{
    public class MSSQLSeatDao : SeatDao
    {
        public MSSQLSeatDao(IConnectionFactory connectionFactory) : base(connectionFactory) { }
    }
}
