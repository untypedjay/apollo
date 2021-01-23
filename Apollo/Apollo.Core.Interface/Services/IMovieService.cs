using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<bool> MovieExists(Movie movie);
        Task Insert(Movie movie);
        Task Delete(Movie movie);
    }
}
