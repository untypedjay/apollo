using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Services
{
    public interface ISeatCategoryService
    {
        Task<IEnumerable<SeatCategory>> GetAllSeatCategories();
        Task<bool> SeatCategoryExists(SeatCategory seatCategory);
        Task<bool> Insert(SeatCategory seatCategory);
        Task<bool> Delete(SeatCategory seatCategory);
    }
}
