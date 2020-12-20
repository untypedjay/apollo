using Apollo.Core.Daos;
using Apollo.Core.Interface.Daos;
using Apollo.Core.Services;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Apollo.Core
{
    public static class ServiceFactory
    {
        static string BaseDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\";
        static IConfiguration config = ConfigurationUtil.GetConfiguration(BaseDirectory);
        static IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration(config, "ApolloTestDbConnection");

        static ICinemaHallDao cinemaHallDao = new MSSQLCinemaHallDao(connectionFactory);
        static IMovieDao movieDao = new MSSQLMovieDao(connectionFactory);
        static IReservationDao reservationDao = new MSSQLReservationDao(connectionFactory);
        static ISeatCategoryDao seatCategoryDao = new MSSQLSeatCategoryDao(connectionFactory);
        static ISeatDao seatDao = new MSSQLSeatDao(connectionFactory);
        static IShowDao showDao = new MSSQLShowDao(connectionFactory);

        static DaoProvider daoProvider = new DaoProvider(cinemaHallDao, movieDao, reservationDao, seatCategoryDao, seatDao, showDao);

        public static ShowService GetShowService()
        {
            return new ShowService(daoProvider);
        }
    }
}
