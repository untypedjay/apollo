using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class SeatDao : ISeatDao
    {
        static string BaseDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\";
        private readonly AdoTemplate template;

        public SeatDao(IConnectionFactory connectionFactory)
        {
            template = new AdoTemplate(connectionFactory);
        }

        public virtual async Task<bool> DeleteAsync(Seat seat)
        {
            return (await template.ExecuteAsync(
                "DELETE FROM Seat WHERE SeatNumber=@sn AND RowNumber=@rn AND locatedIn=@li",
                new QueryParameter("@sn", seat.SeatNumber),
                new QueryParameter("@rn", seat.RowNumber),
                new QueryParameter("@li", seat.CinemaHall.Name)
                )) == 1;
        }

        public virtual async Task<IEnumerable<Seat>> FindAllAsync()
        {
            return await template.QueryAsync<Seat>("SELECT * FROM Seat", MapRowToSeat);
        }

        public virtual async Task<IEnumerable<Seat>> FindByCinemaHallAndSeatCategoryAsync(CinemaHall cinemaHall, SeatCategory seatCategory)
        {
            return await template.QueryAsync<Seat>(
                "SELECT * FROM Seat WHERE locatedIn=@li AND category=@sc",
                MapRowToSeat,
                new QueryParameter("@li", cinemaHall.Name),
                new QueryParameter("@sc", seatCategory.Name));
        }

        public virtual async Task<Seat> FindByCinemaHallAsync(CinemaHall cinemaHall)
        {
            return await template.QuerySingleAsync<Seat>(
                "SELECT * FROM Seat WHERE locatedIn=@li",
                MapRowToSeat,
                new QueryParameter("@li", cinemaHall.Name));
        }

        public virtual async Task<IEnumerable<Seat>> FindByReservationAsync(Reservation reservation)
        {
            return await template.QueryAsync<Seat>(
                "SELECT Seat.SeatNumber, RowNumber, locatedIn, category FROM Reservation" +
                "INNER JOIN reservedSeat ON (Id = reservationId)" +
                "INNER JOIN Seat ON (showIn = locatedIn AND seatRow = RowNumber AND reservedSeat.seatNumber = Seat.SeatNumber)" +
                "WHERE Id=id",
                MapRowToSeat,
                new QueryParameter("@id", reservation.Id));
        }

        public virtual async Task<bool> InsertAsync(Seat seat)
        {
            return (await template.ExecuteAsync(
                "INSERT INTO Seat (SeatNumber, RowNumber, locatedIn, category) VALUES (@sn, @rn, @li, @cat)",
                new QueryParameter("@sn", seat.SeatNumber),
                new QueryParameter("@rn", seat.RowNumber),
                new QueryParameter("@li", seat.CinemaHall.Name),
                new QueryParameter("@cat", seat.SeatCategory.Name)
                )) == 1;
        }

        public virtual async Task<bool> UpdateAsync(Seat seat)
        {
            return (await template.ExecuteAsync(
                "UPDATE Seat SET category=@cat WHERE SeatNumber=@sn AND RowNumber=@rn AND locatedIn=@li",
                new QueryParameter("@sn", seat.SeatNumber),
                new QueryParameter("@rn", seat.RowNumber),
                new QueryParameter("@li", seat.CinemaHall.Name),
                new QueryParameter("@cat", seat.SeatCategory.Name)
                )) == 1;
        }

        private async Task<Seat> MapRowToSeat(IDataRecord row)
        {
            IConfiguration config = ConfigurationUtil.GetConfiguration(BaseDirectory);
            IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration(config, "ApolloTestDbConnection");

            ICinemaHallDao cinemaHallDao = new MSSQLCinemaHallDao(connectionFactory);
            ISeatCategoryDao seatCategoryDao = new MSSQLSeatCategoryDao(connectionFactory);

            return new Seat
            {
                SeatNumber = (int)row["SeatNumber"],
                RowNumber = (int)row["RowNumber"],
                CinemaHall = await cinemaHallDao.FindByNameAsync(row["locatedIn"].ToString()),
                SeatCategory = await seatCategoryDao.FindByNameAsync(row["category"].ToString())
            };
        }
    }
}
