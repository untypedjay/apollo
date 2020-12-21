using Apollo.Domain;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Services
{
    public interface IReservationService
    {
        Task<long> CreateReservation(Show show, int seatNumber, int rowNumber);
        Task<bool> DeleteReservation(long id);
        Task<bool> GetReservationById(long id);
    }
}
