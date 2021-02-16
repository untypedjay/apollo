using Apollo.Core.Interface.Services;
using Apollo.Domain;
using System.Threading.Tasks;

namespace Apollo.Core.Services
{
    public class ReservationService : Service, IReservationService
    {
        public ReservationService(DaoProvider daoProvider) : base(daoProvider)
        {
        }

        public async Task<long> CreateReservation(Show show, int maxSeats, int seatNumber, int rowNumber)
        {
            Reservation reservation = new Reservation(0, maxSeats, show);
            
            long reservationId = await DaoProvider.ReservationDao.InsertAsync(reservation);
            await DaoProvider.ReservedSeatDao.InsertAsync(await GetReservationById(reservationId), seatNumber, rowNumber);
            return reservationId;
        }

        public async Task<bool> DeleteReservation(long id, int seatNumber, int rowNumber)
        {
            await DaoProvider.ReservedSeatDao.DeleteAsync(await GetReservationById(id), seatNumber, rowNumber);
            return await DaoProvider.ReservationDao.DeleteAsync(await GetReservationById(id));
        }

        public async Task<Reservation> GetReservationById(long id)
        {
            return await DaoProvider.ReservationDao.FindByIdAsync(id);
        }
    }
}
