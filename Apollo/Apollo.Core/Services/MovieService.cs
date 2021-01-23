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

        public Task Delete(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public Task Insert(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MovieExists(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
