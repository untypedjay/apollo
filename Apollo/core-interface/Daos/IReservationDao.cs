using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Daos
{
    public interface IReservationDao
    {
        Task<long> InsertAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> FindAllAsync();
        Task<Reservation> FindByIdAsync(long id);
        Task<IEnumerable<Reservation>> FindByShowAsync(Show show);
        Task<bool> UpdateAsync(Reservation reservation);
        Task<bool> DeleteAsync(Reservation reservation);
    }
}
