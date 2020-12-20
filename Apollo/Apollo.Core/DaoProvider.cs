using Apollo.Core.Interface.Daos;

namespace Apollo.Core
{
    public class DaoProvider
    {
        public ICinemaHallDao CinemaHallDao { get; set; }
        public IMovieDao MovieDao { get; set; }
        public IReservationDao ReservationDao { get; set; }
        public ISeatCategoryDao SeatCategoryDao { get; set; }
        public ISeatDao SeatDao { get; set; }
        public IShowDao ShowDao { get; set; }

        public DaoProvider(ICinemaHallDao cinemaHallDao, IMovieDao movieDao, IReservationDao reservationDao,
            ISeatCategoryDao seatCategoryDao, ISeatDao seatDao, IShowDao showDao)
        {
            CinemaHallDao = cinemaHallDao;
            MovieDao = movieDao;
            ReservationDao = reservationDao;
            SeatCategoryDao = seatCategoryDao;
            SeatDao = seatDao;
            ShowDao = showDao;
        }
    }
}
