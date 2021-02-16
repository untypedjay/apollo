using Apollo.Domain;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Services
{
    public interface IReservationService
    {
        Task<long> CreateReservation(Show show, int maxSeats, int seatNumber, int rowNumber);
        Task<bool> DeleteReservation(long id, int seatNumber, int rowNumber);
        Task<Reservation> GetReservationById(long id);
    }
}
