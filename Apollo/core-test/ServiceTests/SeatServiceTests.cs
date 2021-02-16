using Apollo.Core.Services;
using Apollo.Domain;
using System;
using System.Linq;
using Xunit;

namespace Apollo.Core.Test.ServiceTests
{
    public class SeatServiceTests
    {
        SeatService seatService = ServiceFactory.GetSeatService();

        [Fact]
        public async void GetReservedSeatsByShowTest()
        {
            Movie movie = new Movie("Jean de Florette", "At a key turning point for the Catholic Church, Pope Benedict XVI forms a surprising friendship with the future Pope Francis. Inspired by true events.", "Thriller", 125.0, "Anthony Hopkins, Jonathan Pryce, Juan Minujin", "https://cdn.collider.com/wp-content/uploads/2019/07/the-two-popes-anthony-hopkins-jonathan-pryce-1.jpg", "https://www.youtube.com/watch?v=T5OhkFY1PQE");
            CinemaHall cinemaHall = new CinemaHall("SAAL 3", 23, 10);
            Show show = new Show(new DateTime(2020, 11, 01, 04, 46, 24), movie, cinemaHall);
            var reservedSeats = await seatService.GetReservedSeatsByShow(show);
            Assert.Equal(0, reservedSeats.Count());
        }

        [Fact]
        public async void GetSeatsByCinemaHallTest()
        {
            CinemaHall cinemaHall = new CinemaHall("SAAL 3", 23, 10);
            var seats = await seatService.GetSeatsByCinemaHall(cinemaHall);
            Assert.Equal(0, seats.Count());
        }
    }
}