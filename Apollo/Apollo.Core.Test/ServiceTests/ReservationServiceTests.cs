using Apollo.Core.Services;
using Apollo.Domain;
using System;
using Xunit;

namespace Apollo.Core.Test.ServiceTests
{
    public class ReservationServiceTests
    {
        ReservationService reservationService = ServiceFactory.GetReservationService();

        [Fact]
        public async void CreateAndDeleteReservationTest()
        {
            Movie movie = new Movie("Jean de Florette", "At a key turning point for the Catholic Church, Pope Benedict XVI forms a surprising friendship with the future Pope Francis. Inspired by true events.", "Thriller", 125.0, "Anthony Hopkins, Jonathan Pryce, Juan Minujin", "https://cdn.collider.com/wp-content/uploads/2019/07/the-two-popes-anthony-hopkins-jonathan-pryce-1.jpg", "https://www.youtube.com/watch?v=T5OhkFY1PQE");
            CinemaHall cinemaHall = new CinemaHall("SAAL 3", 23, 10);
            Show show = new Show(new DateTime(2020, 11, 01, 04, 46, 24), movie, cinemaHall);
            long reservationId = await reservationService.CreateReservation(show, 10, 8, 4);
            Assert.NotEqual(0, reservationId);
            Assert.True(await reservationService.DeleteReservation(reservationId, 8, 4));
        }

        [Fact]
        public async void GetReservationByIdTest()
        {
            long reservationId = 34;
            Reservation reservation = await reservationService.GetReservationById(reservationId);
            Assert.Equal(reservation.Id, reservationId);
        }
    }
}