using Apollo.Core.Daos;
using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Apollo.Core.Test
{
    public class SeatDaoTests
    {
        static string BaseDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\";
        static IConfiguration config = ConfigurationUtil.GetConfiguration(BaseDirectory);
        static IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration(config, "ApolloTestDbConnection");
        ISeatDao seatDao = new MSSQLSeatDao(connectionFactory);
        ICinemaHallDao cinemaHallDao = new MSSQLCinemaHallDao(connectionFactory);
        ISeatCategoryDao seatCategoryDao = new MSSQLSeatCategoryDao(connectionFactory);
        IReservationDao reservationDao = new MSSQLReservationDao(connectionFactory);

        [Fact]
        public async void InsertAsyncTest()
        {
            CinemaHall cinemaHall = await cinemaHallDao.FindByNameAsync("SAAL 2");
            SeatCategory seatCategory = await seatCategoryDao.FindByNameAsync("CINEGOLD");
            Seat seat = new Seat(2, 2, cinemaHall, seatCategory);
            Assert.True(await seatDao.InsertAsync(seat));
            await seatDao.DeleteAsync(seat);
        }

        [Fact]
        public async void FindAllAsyncTest()
        {
            ICollection<Seat> seats = (ICollection<Seat>)await seatDao.FindAllAsync();
            Assert.Equal(41, seats.Count);
        }

        [Fact]
        public async void FindByCinemaHallAsyncTest()
        {
            CinemaHall cinemaHall = await cinemaHallDao.FindByNameAsync("IMAX SAAL 1");
            ICollection<Seat> seats = (ICollection<Seat>)await seatDao.FindByCinemaHallAsync(cinemaHall);
            Assert.Equal(11, seats.Count);
        }

        [Fact]
        public async void FindByReservationAsyncTest()
        {
            Reservation reservation = await reservationDao.FindByIdAsync(12);
            ICollection<Seat> seats = (ICollection<Seat>)await seatDao.FindByReservationAsync(reservation);
            Assert.Equal(1, seats.Count);
        }

        [Fact]
        public async void FindByCinemaHallAndSeatCategoryAsyncTest()
        {
            CinemaHall cinemaHall = await cinemaHallDao.FindByNameAsync("IMAX SAAL 1");
            SeatCategory seatCategory = await seatCategoryDao.FindByNameAsync("CINEGOLD");
            ICollection<Seat> seats = (ICollection<Seat>)await seatDao.FindByCinemaHallAndSeatCategoryAsync(cinemaHall, seatCategory);
            Assert.Equal(1, seats.Count);
        }

        [Fact]
        public async void UpdateAsyncTest()
        {
            CinemaHall cinemaHall = await cinemaHallDao.FindByNameAsync("IMAX SAAL 1");
            SeatCategory seatCategory1 = await seatCategoryDao.FindByNameAsync("CINEGOLD");
            SeatCategory seatCategory2 = await seatCategoryDao.FindByNameAsync("BASIC");
            Seat seat = new Seat(30, 11, cinemaHall, seatCategory2);
            ICollection<Seat> result = (ICollection<Seat>)await seatDao.FindByCinemaHallAndSeatCategoryAsync(cinemaHall, seatCategory1);
            Seat resultSeat = null;
            foreach (var potentialSeat in result)
            {
                resultSeat = potentialSeat;
            }
            Assert.NotEqual(seat.SeatCategory.Name, resultSeat.SeatCategory.Name);
            Assert.True(await seatDao.UpdateAsync(seat));
            ICollection<Seat> result2 = (ICollection<Seat>)await seatDao.FindByCinemaHallAndSeatCategoryAsync(cinemaHall, seatCategory2);
            Seat resultSeat2 = null;
            foreach (var potentialSeat in result2)
            {
                resultSeat2 = potentialSeat;
            }
            Assert.Equal(seat.SeatCategory.Name, resultSeat2.SeatCategory.Name);
            Assert.True(await seatDao.UpdateAsync(resultSeat));
            ICollection<Seat> result3 = (ICollection<Seat>)await seatDao.FindByCinemaHallAndSeatCategoryAsync(cinemaHall, seatCategory1);
            Seat resultSeat3 = null;
            foreach (var potentialSeat in result3)
            {
                resultSeat3 = potentialSeat;
            }
            Assert.NotEqual(seat.SeatCategory.Name, resultSeat3.SeatCategory.Name);
        }

        [Fact]
        public async void DeleteAsyncTest()
        {
            CinemaHall cinemaHall = await cinemaHallDao.FindByNameAsync("SAAL 2");
            SeatCategory seatCategory = await seatCategoryDao.FindByNameAsync("CINEGOLD");
            Seat seat = new Seat(2, 2, cinemaHall, seatCategory);
            await seatDao.InsertAsync(seat);
            Assert.True(await seatDao.DeleteAsync(seat));
        }
    }
}