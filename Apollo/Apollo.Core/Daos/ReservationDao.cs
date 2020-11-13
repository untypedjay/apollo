using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class ReservationDao : IReservationDao
    {
        public Task<bool> DeleteAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> FindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> FindByShow(Show show)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
