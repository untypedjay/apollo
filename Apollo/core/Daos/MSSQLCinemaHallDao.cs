namespace Apollo.Core.Daos
{
    public class MSSQLCinemaHallDao : CinemaHallDao
    {
        public MSSQLCinemaHallDao(IConnectionFactory connectionFactory) : base(connectionFactory) { }
    }
}
