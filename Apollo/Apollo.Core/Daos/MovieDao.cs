using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class MovieDao : IMovieDao
    {
        public Task<bool> DeleteAsync(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Movie>> FindAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Movie>> FindByGenreAsync(string genre)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Movie>> FindByLengthGreaterAsync(double length)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Movie>> FindByLengthLessAsync(double length)
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> FindByTitleAsync(string title)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertAsync(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(Movie movie)
        {
            throw new System.NotImplementedException();
        }
    }
}
