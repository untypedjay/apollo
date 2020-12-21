using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System.IO;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class ReservedSeatDao : IReservedSeatDao
    {
        private readonly AdoTemplate template;

        public ReservedSeatDao(IConnectionFactory connectionFactory)
        {
            template = new AdoTemplate(connectionFactory);
        }

        public virtual async Task<bool> DeleteAsync(Reservation reservation, int seatNumber, int seatRow)
        {
            return (await template.ExecuteAsync(
                "DELETE FROM reservedSeat WHERE seatNumber=@sn AND seatRow=@sr AND seatLocation=@sl AND reservationId=@ri",
                new QueryParameter("@sn", seatNumber),
                new QueryParameter("@sr", seatRow),
                new QueryParameter("@sl", reservation.Show.CinemaHall.Name),
                new QueryParameter("@ri", reservation.Id)
                )) == 1;
        }

        public virtual async Task<bool> InsertAsync(Reservation reservation, int seatNumber, int seatRow)
        {
            return (await template.ExecuteAsync(
                "INSERT INTO reservedSeat (seatNumber, seatRow, seatLocation, reservationId) VALUES (@sn, @sr, @sl, @ri)",
                new QueryParameter("@sn", seatNumber),
                new QueryParameter("@sr", seatRow),
                new QueryParameter("@sl", reservation.Show.CinemaHall.Name),
                new QueryParameter("@ri", reservation.Id)
                )) == 1;
        }

        public virtual async Task<bool> IsReservedAsync(Reservation reservation, int seatNumber, int seatRow)
        {
            return (await template.ExecuteAsync(
                "SELECT COUNT(*) FROM reservedSeat WHERE seatNumber=@sn AND seatRow=@sr AND seatLocation=@sl AND reservationId=@ri",
                new QueryParameter("@sn", seatNumber),
                new QueryParameter("@sr", seatRow),
                new QueryParameter("@sl", reservation.Show.CinemaHall.Name),
                new QueryParameter("@ri", reservation.Id)
                )) == 1;
        }
    }
}