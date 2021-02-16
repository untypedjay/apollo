using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Daos
{
    public interface ICinemaHallDao
    {
        Task<bool> InsertAsync(CinemaHall cinemaHall);
        Task<IEnumerable<CinemaHall>> FindAllAsync();
        Task<CinemaHall> FindByNameAsync(string name);
        Task<bool> UpdateAsync(CinemaHall cinemaHall);
        Task<bool> DeleteAsync(CinemaHall cinemaHall);
    }
}
