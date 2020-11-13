using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class CinemaHallDao : ICinemaHallDao
    {
        public Task<bool> DeleteAsync(CinemaHall cinemaHall)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CinemaHall>> FindAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<CinemaHall> FindByNameAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertAsync(CinemaHall cinemaHall)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(CinemaHall cinemaHall)
        {
            throw new System.NotImplementedException();
        }
    }
}
