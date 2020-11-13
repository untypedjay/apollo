using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class SeatCategoryDao : ISeatCategoryDao
    {
        public Task<bool> DeleteAsync(SeatCategory seatCategory)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SeatCategory>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SeatCategory> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SeatCategory>> FindByPriceGreaterAsync(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SeatCategory>> FindByPriceLessAsync(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(SeatCategory seatCategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(SeatCategory seatCategory)
        {
            throw new NotImplementedException();
        }
    }
}
