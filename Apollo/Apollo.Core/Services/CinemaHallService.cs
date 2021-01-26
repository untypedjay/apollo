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
            bool insertSuccess = await DaoProvider.CinemaHallDao.InsertAsync(cinemaHall);
            if (insertSuccess)
            {
                IList<SeatCategory> seatCategories = (IList<SeatCategory>)await DaoProvider.SeatCategoryDao.FindAllAsync();
                await CreateSeats(1, cinemaHall.RowAmount - 4, seatCategories[0], cinemaHall);
                await CreateSeats(cinemaHall.RowAmount - 3, cinemaHall.RowAmount - 1, seatCategories[1], cinemaHall);
                await CreateSeats(cinemaHall.RowAmount, cinemaHall.RowAmount, seatCategories[2], cinemaHall);
            }

            return insertSuccess;
        }

        private async Task<bool> CreateSeats(int startRow, int endRow, SeatCategory seatCategory, CinemaHall cinemaHall)
        {
            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = 1; j <= cinemaHall.SeatAmount; j++)
                {
                    Seat seat = new Seat(j, i, cinemaHall, seatCategory);
                    await DaoProvider.SeatDao.InsertAsync(seat);
                }
            }
            return true;
        }
    }
}
