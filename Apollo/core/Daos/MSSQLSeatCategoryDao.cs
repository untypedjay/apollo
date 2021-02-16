namespace Apollo.Core.Daos
{
    public class MSSQLSeatCategoryDao : SeatCategoryDao
    {
        public MSSQLSeatCategoryDao(IConnectionFactory connectionFactory) : base(connectionFactory) { }
    }
}
