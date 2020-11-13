using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class SeatDao : ISeatDao
    {
        public Task<bool> DeleteAsync(Seat seat)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Seat>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Seat>> FindByCinemaHallAndSeatCategoryAsync(CinemaHall cinemaHall, SeatCategory seatCategory)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Seat>> FindByCinemaHallAsync(CinemaHall cinemaHall)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Seat>> FindByReservationAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Seat seat)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Seat seat)
        {
            throw new NotImplementedException();
        }
    }
}
