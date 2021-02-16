using Apollo.Core.Interface.Services;
using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Services
{
    public class SeatCategoryService : Service, ISeatCategoryService
    {
        public SeatCategoryService(DaoProvider daoProvider) : base(daoProvider)
        {
        }

        public async Task<bool> Delete(SeatCategory seatCategory)
        {
            return await DaoProvider.SeatCategoryDao.DeleteAsync(seatCategory);
        }

        public async Task<IEnumerable<SeatCategory>> GetAllSeatCategories()
        {
            return await DaoProvider.SeatCategoryDao.FindAllAsync();
        }

        public async Task<bool> Insert(SeatCategory seatCategory)
        {
            return await DaoProvider.SeatCategoryDao.InsertAsync(seatCategory);
        }

        public async Task<bool> SeatCategoryExists(SeatCategory seatCategory)
        {
            if (await DaoProvider.SeatCategoryDao.FindByNameAsync(seatCategory.Name) == null)
            {
                return false;
            }

            return true;
        }
    }
}
