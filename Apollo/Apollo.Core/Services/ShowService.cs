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
    }
}
