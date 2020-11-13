using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Daos
{
    public interface ISeatCategoryDao
    {
        Task<bool> InsertAsync(SeatCategory seatCategory);
        Task<IEnumerable<SeatCategory>> FindAllAsync();
        Task<SeatCategory> FindByNameAsync(string name);
        Task<IEnumerable<SeatCategory>> FindByPriceGreaterAsync(decimal price);
        Task<IEnumerable<SeatCategory>> FindByPriceLessAsync(decimal price);
        Task<bool> UpdateAsync(SeatCategory seatCategory);
        Task<bool> DeleteAsync(SeatCategory seatCategory);
    }
}
