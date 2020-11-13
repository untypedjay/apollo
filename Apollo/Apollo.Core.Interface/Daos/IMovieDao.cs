using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Daos
{
    interface IMovieDao
    {
        Task<bool> InsertAsync(Movie movie);
        Task<IEnumerable<Movie>> FindAllAsync();
        Task<Movie> FindByTitleAsync(string title);
        Task<IEnumerable<Movie>> FindByGenreAsync(string genre);
        Task<IEnumerable<Movie>> FindByLengthGreaterAsync(double length);
        Task<IEnumerable<Movie>> FindByLengthLessAsync(double length);
        Task<bool> UpdateAsync(Movie movie);
        Task<bool> DeleteAsync(Movie movie);
    }
}
