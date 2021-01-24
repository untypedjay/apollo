using Apollo.Core.Interface.Services;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Services
{
    public class MovieService : Service, IMovieService
    {
        public MovieService(DaoProvider daoProvider) : base(daoProvider)
        {
        }

        public async Task<bool> Delete(Movie movie)
        {
            return await DaoProvider.MovieDao.DeleteAsync(movie);
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await DaoProvider.MovieDao.FindAllAsync();
        }

        public async Task<bool> Insert(Movie movie)
        {
            return await DaoProvider.MovieDao.InsertAsync(movie);
        }

        public async Task<bool> MovieExists(Movie movie)
        {
            if (await DaoProvider.MovieDao.FindByTitleAsync(movie.Title) == null)
            {
                return false;
            }

            return true;
        }
    }
}
