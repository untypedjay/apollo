using Apollo.Core.Interface.Services;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Core.Services
{
    public class CinemaHallService : Service, ICinemaHallService
    {
        public CinemaHallService(DaoProvider daoProvider) : base(daoProvider)
        {
        }

        public async Task<bool> CinemaHallExists(CinemaHall cinemaHall)
        {
            if (await DaoProvider.CinemaHallDao.FindByNameAsync(cinemaHall.Name) == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(CinemaHall cinemaHall)
        {
            return await DaoProvider.CinemaHallDao.DeleteAsync(cinemaHall);
        }

        public async Task<IEnumerable<CinemaHall>> GetAllCinemaHalls()
        {
            return await DaoProvider.CinemaHallDao.FindAllAsync();
        }

        public async Task<bool> Insert(CinemaHall cinemaHall)
        {
            return await DaoProvider.CinemaHallDao.InsertAsync(cinemaHall);
        }
    }
}
