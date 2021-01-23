using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Daos
{
    public interface IShowDao
    {
        Task<bool> InsertAsync(Show show);
        Task<IEnumerable<Show>> FindAllAsync();
        Task<Show> FindByDateCinemaHallAndMovieAsync(DateTime date, CinemaHall cinemaHall, Movie movie);
        Task<IEnumerable<Show>> FindByDateAsync(DateTime date);
        Task<IEnumerable<Show>> FindByExactDateAsync(DateTime date);
        Task<Show> FindByExactTimeStampAsync(DateTime date);
        Task<IEnumerable<Show>> FindByCinemaHallAsync(CinemaHall cinemaHall);
        Task<IEnumerable<Show>> FindByMovieAsync(Movie movie);
        Task<bool> DeleteAsync(Show show);
    }
}
