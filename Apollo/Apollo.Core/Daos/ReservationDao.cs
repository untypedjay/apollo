using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class ReservationDao : IReservationDao
    {
        private readonly AdoTemplate template;

        public ReservationDao(IConnectionFactory connectionFactory)
        {
            template = new AdoTemplate(connectionFactory);
        }

        public virtual async Task<bool> DeleteAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Reservation>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Reservation> FindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Reservation>> FindByShow(Show show)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> InsertAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> UpdateAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
