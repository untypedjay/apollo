using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class SeatDao : ISeatDao
    {
        private readonly AdoTemplate template;

        public SeatDao(IConnectionFactory connectionFactory)
        {
            template = new AdoTemplate(connectionFactory);
        }

        public virtual async Task<bool> DeleteAsync(Seat seat)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Seat>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Seat>> FindByCinemaHallAndSeatCategoryAsync(CinemaHall cinemaHall, SeatCategory seatCategory)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Seat>> FindByCinemaHallAsync(CinemaHall cinemaHall)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Seat>> FindByReservationAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> InsertAsync(Seat seat)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> UpdateAsync(Seat seat)
        {
            throw new NotImplementedException();
        }
    }
}
