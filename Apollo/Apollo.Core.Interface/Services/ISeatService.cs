using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Services
{
    public interface ISeatService
    {
        Task<IEnumerable<Seat>> GetSeatsByCinemaHall(CinemaHall cinemaHall);
        Task<IEnumerable<Seat>> GetReservedSeatsByShow(Show show);
    }
}
