using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Data;
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
            return (await template.ExecuteAsync(
                "DELETE FROM SeatCategory WHERE CategoryName=@cn",
                new QueryParameter("@cn", seatCategory.Name)
                )) == 1;
        }

        public virtual async Task<IEnumerable<SeatCategory>> FindAllAsync()
        {
            return await template.QueryAsync<SeatCategory>("SELECT * FROM SeatCategory", MapRowToSeatCategory);
        }

        public virtual async Task<SeatCategory> FindByNameAsync(string name)
        {
            return await template.QuerySingleAsync<SeatCategory>(
                "SELECT * FROM SeatCategory WHERE CategoryName=@cn",
                MapRowToSeatCategory,
                new QueryParameter("@cn", name));
        }

        public virtual async Task<IEnumerable<SeatCategory>> FindByPriceGreaterAsync(decimal price)
        {
            return await template.QueryAsync<SeatCategory>(
                "SELECT * FROM SeatCategory WHERE Price>@price",
                MapRowToSeatCategory,
                new QueryParameter("@price", price));
        }

        public virtual async Task<IEnumerable<SeatCategory>> FindByPriceLessAsync(decimal price)
        {
            return await template.QueryAsync<SeatCategory>(
                "SELECT * FROM SeatCategory WHERE Price<@price",
                MapRowToSeatCategory,
                new QueryParameter("@price", price));
        }

        public virtual async Task<bool> InsertAsync(SeatCategory seatCategory)
        {
            return (await template.ExecuteAsync(
                "INSERT INTO SeatCategory (CategoryName, Price) VALUES (@cn, @price)",
                new QueryParameter("@cn", seatCategory.Name),
                new QueryParameter("@price", seatCategory.Price)
                )) == 1;
        }

        public virtual async Task<bool> UpdateAsync(SeatCategory seatCategory)
        {
            return (await template.ExecuteAsync(
                "UPDATE SeatCategory SET Price=@price WHERE CategoryName=@cn",
                new QueryParameter("@cn", seatCategory.Name),
                new QueryParameter("@price", seatCategory.Price)
                )) == 1;
        }

        private SeatCategory MapRowToSeatCategory(IDataRecord row)
        {
            return new SeatCategory(
                (string)row["CategoryName"],
                (decimal)row["Price"]
            );
        }
    }
}
