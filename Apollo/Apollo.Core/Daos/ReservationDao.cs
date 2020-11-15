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
    public abstract class ReservationDao : IReservationDao
    {
        protected abstract string LastInsertIdQuery { get; }
        static string BaseDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\";
        private readonly AdoTemplate template;

        public ReservationDao(IConnectionFactory connectionFactory)
        {
            template = new AdoTemplate(connectionFactory);
        }

        public virtual async Task<bool> DeleteAsync(Reservation reservation)
        {
            return (await template.ExecuteAsync(
                "DELETE FROM Reservation WHERE Id=@id",
                new QueryParameter("@id", reservation.Id)
                )) == 1;
        }

        public virtual async Task<IEnumerable<Reservation>> FindAllAsync()
        {
            return await template.QueryAsync<Reservation>("SELECT * FROM Reservation", MapRowToReservation);
        }

        public virtual async Task<Reservation> FindByIdAsync(long id)
        {
            return await template.QuerySingleAsync<Reservation>(
                "SELECT * FROM Reservation WHERE Id=@id",
                MapRowToReservation,
                new QueryParameter("@id", id));
        }

        public virtual async Task<IEnumerable<Reservation>> FindByShowAsync(Show show)
        {
            return await template.QueryAsync<Reservation>(
                "SELECT * FROM Reservation WHERE showBegins=@sb AND showMovie=@sm AND showIn=@si",
                MapRowToReservation,
                new QueryParameter("@sb", show.StartsAt),
                new QueryParameter("@sm", show.Movie.Title),
                new QueryParameter("@si", show.CinemaHall.Name));
        }

        public virtual async Task<bool> InsertAsync(Reservation reservation)
        {
            return (await template.ExecuteAsync(
                "INSERT INTO Reservation (Id, MaxSeats, showBegins, showMovie, showIn) VALUES (@id, @ms, @sb, @sm, @si)",
                new QueryParameter("@ms", reservation.MaxSeats),
                new QueryParameter("@sb", reservation.Show.StartsAt),
                new QueryParameter("@sm", reservation.Show.Movie.Title),
                new QueryParameter("@si", reservation.Show.CinemaHall.Name),
                new QueryParameter("@id", reservation.Id)
                )) == 1;
        }

        public virtual async Task<bool> UpdateAsync(Reservation reservation)
        {
            return (await template.ExecuteAsync(
                "UPDATE Reservation SET MaxSeats=@ms, showBegins=@sb, showMovie=@sm, showIn=@si WHERE Id=@id",
                new QueryParameter("@ms", reservation.MaxSeats),
                new QueryParameter("@sb", reservation.Show.StartsAt),
                new QueryParameter("@sm", reservation.Show.Movie.Title),
                new QueryParameter("@si", reservation.Show.CinemaHall.Name),
                new QueryParameter("@id", reservation.Id)
                )) == 1;
        }

        private async Task<Reservation> MapRowToReservation(IDataRecord row)
        {
            IConfiguration config = ConfigurationUtil.GetConfiguration(BaseDirectory);
            IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration(config, "ApolloTestDbConnection");

            IShowDao showDao = new MSSQLShowDao(connectionFactory);
            ICinemaHallDao cinemaHallDao = new MSSQLCinemaHallDao(connectionFactory);
            IMovieDao movieDao = new MSSQLMovieDao(connectionFactory);

            return new Reservation(
                (long)row["Id"],
                (int)row["MaxSeats"],
                await showDao.FindByDateCinemaHallAndMovieAsync(
                    (DateTime)row["showBegins"],
                    await cinemaHallDao.FindByNameAsync(row["showIn"].ToString()),
                    await movieDao.FindByTitleAsync(row["showMovie"].ToString()))
            );
        }
    }
}
