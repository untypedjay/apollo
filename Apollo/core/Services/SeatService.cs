using Apollo.Core.Interface.Services;
using Apollo.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Apollo.Core.Services
{
    public class SeatService : Service, ISeatService
    {
        public SeatService(DaoProvider daoProvider) : base(daoProvider)
        {
        }

        public async Task<IEnumerable<Seat>> GetReservedSeatsByShow(Show show)
        {
            IEnumerable<Reservation> reservations = await DaoProvider.ReservationDao.FindByShowAsync(show);
            IEnumerable<Seat> seats = await GetSeatsByCinemaHall(show.CinemaHall);
            ICollection<Seat> reservedSeats = new Collection<Seat>();
            foreach (var seat in seats)
            {
                foreach (var reservation in reservations)
                {
                    if (await DaoProvider.ReservedSeatDao.IsReservedAsync(reservation, seat.SeatNumber, seat.RowNumber))
                    {
                        reservedSeats.Add(seat);
                    }
                }
            }

            return reservedSeats;
        }

        public async Task<IEnumerable<Seat>> GetSeatsByCinemaHall(CinemaHall cinemaHall)
        {
            return await DaoProvider.SeatDao.FindByCinemaHallAsync(cinemaHall);
        }
    }
}
