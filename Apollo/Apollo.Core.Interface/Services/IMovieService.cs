using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Services
{
    interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovies();
    }
}
