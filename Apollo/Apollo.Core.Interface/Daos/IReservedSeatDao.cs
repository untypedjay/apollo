using Apollo.Domain;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Daos
{
    public interface IReservedSeatDao
    {
        Task<bool> InsertAsync(Reservation reservation, int seatNumber, int seatRow);
        Task<bool> DeleteAsync(Reservation reservation, int seatNumber, int seatRow);
        Task<bool> IsReservedAsync(Seat seat, Show show);
    }
}