using Apollo.Core.Interface.Services;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Services
{
    public class ShowService : Service, IShowService
    {
        public ShowService(DaoProvider daoProvider) : base(daoProvider)
        {
        }

        public async Task<bool> Delete(Show show)
        {
            return await DaoProvider.ShowDao.DeleteAsync(show);
        }

        public async Task<IEnumerable<Show>> GetAllShows()
        {
            return await DaoProvider.ShowDao.FindAllAsync();
        }

        public async Task<int> GetCapacityByShow(Show show)
        {
            ICollection<Reservation> reservations = (ICollection<Reservation>)await DaoProvider.ReservationDao.FindByShowAsync(show);
            return reservations.Count;
        }

        public async Task<IEnumerable<Show>> GetShowsByGenreSearch(string search)
        {
            var movies = await DaoProvider.MovieDao.FindByGenreAsync(search);
            var shows = new List<Show>();
            foreach (var movie in movies)
            {
                shows.AddRange(await DaoProvider.ShowDao.FindByMovieAsync(movie));
            }
            return shows;
        }

        public async Task<IEnumerable<Show>> GetShowsByMovieSearch(string search)
        {
            Movie movie = await DaoProvider.MovieDao.FindByTitleAsync(search);
            return await DaoProvider.ShowDao.FindByMovieAsync(movie);
        }

        public async Task<IEnumerable<Show>> GetShowsToday()
        {
            return await DaoProvider.ShowDao.FindByExactDateAsync(DateTime.Now);
        }

        public async Task<bool> Insert(Show show)
        {
            return await DaoProvider.ShowDao.InsertAsync(show);
        }

        public async Task<bool> ShowExists(Show show)
        {
            if (await DaoProvider.MovieDao.FindByTitleAsync(show.Movie.Title) == null ||
                await DaoProvider.CinemaHallDao.FindByNameAsync(show.CinemaHall.Name) == null ||
                await DaoProvider.ShowDao.FindByExactTimeStampAsync(show.StartsAt) == null)
            {
                return false;
            }

            return true;
        }
    }
}
