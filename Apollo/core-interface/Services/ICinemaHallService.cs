using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Services
{
    public interface ICinemaHallService
    {
        Task<IEnumerable<CinemaHall>> GetAllCinemaHalls();
        Task<bool> CinemaHallExists(CinemaHall cinemaHall);
        Task<bool> Insert(CinemaHall cinemaHall);
        Task<bool> Delete(CinemaHall cinemaHall);
    }
}
