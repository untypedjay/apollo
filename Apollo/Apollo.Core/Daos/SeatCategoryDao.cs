using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class SeatCategoryDao : ISeatCategoryDao
    {
        private readonly AdoTemplate template;

        public SeatCategoryDao(IConnectionFactory connectionFactory)
        {
            template = new AdoTemplate(connectionFactory);
        }

        public virtual async Task<bool> DeleteAsync(SeatCategory seatCategory)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<SeatCategory>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<SeatCategory> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<SeatCategory>> FindByPriceGreaterAsync(decimal price)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<SeatCategory>> FindByPriceLessAsync(decimal price)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> InsertAsync(SeatCategory seatCategory)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> UpdateAsync(SeatCategory seatCategory)
        {
            throw new NotImplementedException();
        }
    }
}
