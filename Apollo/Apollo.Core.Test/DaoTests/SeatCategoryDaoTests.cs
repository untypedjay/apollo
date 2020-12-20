using Apollo.Core.Daos;
using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Apollo.Core.Test
{
    public class SeatCategoryDaoTests
    {
        static string BaseDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\";
        static IConfiguration config = ConfigurationUtil.GetConfiguration(BaseDirectory);
        static IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration(config, "ApolloTestDbConnection");
        ISeatCategoryDao seatCategoryDao = new MSSQLSeatCategoryDao(connectionFactory);

        [Fact]
        public async void InsertAsyncTest()
        {
            SeatCategory category = new SeatCategory("SUPERIOR", 20.99m);
            Assert.True(await seatCategoryDao.InsertAsync(category));
            await seatCategoryDao.DeleteAsync(category);
        }

        [Fact]
        public async void FindAllAsyncTest()
        {
            ICollection<SeatCategory> seatCategories = (ICollection<SeatCategory>)await seatCategoryDao.FindAllAsync();
            Assert.Equal(3, seatCategories.Count);
        }

        [Fact]
        public async void FindByNameAsyncTest()
        {
            SeatCategory seatCategory = await seatCategoryDao.FindByNameAsync("BASIC");
            Assert.Equal("BASIC", seatCategory.Name);
        }

        [Fact]
        public async void FindByPriceGreaterAsyncTest()
        {
            ICollection<SeatCategory> seatCategories = (ICollection<SeatCategory>)await seatCategoryDao.FindByPriceGreaterAsync(9.4m);
            Assert.Equal(2, seatCategories.Count);
        }

        [Fact]
        public async void FindByPriceLessAsyncTest()
        {
            ICollection<SeatCategory> seatCategories = (ICollection<SeatCategory>)await seatCategoryDao.FindByPriceLessAsync(9.4m);
            Assert.Equal(1, seatCategories.Count);
        }

        [Fact]
        public async void UpdateAsyncTest()
        {
            SeatCategory seatCategory = new SeatCategory("BASIC", 8m);
            SeatCategory result = await seatCategoryDao.FindByNameAsync("BASIC");
            Assert.NotEqual(seatCategory.Price, result.Price);
            Assert.True(await seatCategoryDao.UpdateAsync(seatCategory));
            SeatCategory result2 = await seatCategoryDao.FindByNameAsync("BASIC");
            Assert.Equal(seatCategory.Price, result2.Price);
            Assert.True(await seatCategoryDao.UpdateAsync(result));
            SeatCategory result3 = await seatCategoryDao.FindByNameAsync("BASIC");
            Assert.NotEqual(seatCategory.Price, result3.Price);
        }

        [Fact]
        public async void DeleteAsyncTest()
        {
            SeatCategory category = new SeatCategory("SUPERIOR", 20.99m);
            await seatCategoryDao.InsertAsync(category);
            Assert.True(await seatCategoryDao.DeleteAsync(category));
        }
    }
}