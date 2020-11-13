using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Daos
{
    interface IShowDao
    {
        Task<bool> InsertAsync(Show show);
        Task<IEnumerable<Show>> FindAllAsync();
        Task<IEnumerable<Show>> FindByDateAsync(DateTime date);
        Task<IEnumerable<Show>> FindByExactDateAsync(DateTime date);
        Task<IEnumerable<Show>> FindByCinemaHall(CinemaHall cinemaHall);
        Task<IEnumerable<Show>> FindByMovie(Movie movie);
        Task<bool> UpdateAsync(Show show);
        Task<bool> DelegeAsync(Show show);
    }
}
