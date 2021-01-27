using Apollo.Core.Daos;
using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Apollo.Core.Test
{
    public class CinemaHallDaoTests
    {
        static string BaseDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\";
        static IConfiguration config = ConfigurationUtil.GetConfiguration(BaseDirectory);
        static IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration(config, "ApolloTestDbConnection");
        ICinemaHallDao cinemaHallDao = new MSSQLCinemaHallDao(connectionFactory);

        [Fact]
        public async void InsertAsyncTest()
        {
            CinemaHall cinemaHall = new CinemaHall("SAAL 23", 23, 10);
            Assert.True(await cinemaHallDao.InsertAsync(cinemaHall));
            await cinemaHallDao.DeleteAsync(cinemaHall);
        }

        [Fact]
        public async void FindAllAsyncTest()
        {
            ICollection<CinemaHall> cinemaHalls = (ICollection<CinemaHall>)await cinemaHallDao.FindAllAsync();
            Assert.Equal(5, cinemaHalls.Count);
        }

        [Fact]
        public async void FindByNameAsyncTest()
        {
            CinemaHall cinemaHall = await cinemaHallDao.FindByNameAsync("IMAX HALL 1");
            Assert.Equal("IMAX HALL 1", cinemaHall.Name);
        }

        [Fact]
        public async void UpdateAsyncTest()
        {
            CinemaHall cinemaHall = new CinemaHall("HALL 2", 23, 10);
            CinemaHall result = await cinemaHallDao.FindByNameAsync("HALL 2");
            Assert.NotEqual(cinemaHall.RowAmount, result.RowAmount);
            Assert.True(await cinemaHallDao.UpdateAsync(cinemaHall));
            CinemaHall result2 = await cinemaHallDao.FindByNameAsync("HALL 2");
            Assert.Equal(cinemaHall.RowAmount, result2.RowAmount);
            Assert.True(await cinemaHallDao.UpdateAsync(result));
            CinemaHall result3 = await cinemaHallDao.FindByNameAsync("HALL 2");
            Assert.NotEqual(cinemaHall.RowAmount, result3.RowAmount);
        }

        [Fact]
        public async void DeleteAsyncTest()
        {
            CinemaHall cinemaHall = new CinemaHall("SAAL 23", 23, 10);
            await cinemaHallDao.InsertAsync(cinemaHall);
            Assert.True(await cinemaHallDao.DeleteAsync(cinemaHall));
        }
    }
}