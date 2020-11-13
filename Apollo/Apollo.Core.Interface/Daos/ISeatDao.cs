using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Daos
{
    interface ISeatDao
    {
        Task<bool> InsertAsync(Seat seat);
        Task<IEnumerable<Seat>> FindAllAsync();
        Task<IEnumerable<Seat>> FindByCinemaHallAsync(CinemaHall cinemaHall);
        Task<IEnumerable<Seat>> FindByReservationAsync(Reservation reservation);
        Task<IEnumerable<Seat>> FindByCinemaHallAndSeatCategoryAsync(CinemaHall cinemaHall, SeatCategory seatCategory);
        Task<bool> UpdateAsync(Seat seat);
        Task<bool> DeleteAsync(Seat seat);
    }
}
