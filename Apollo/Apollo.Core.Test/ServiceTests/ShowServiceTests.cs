using Apollo.Core.Services;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace Apollo.Core.Test.ServiceTests
{
    public class ShowServiceTests
    {
        ShowService showService = ServiceFactory.GetShowService();

        [Fact]
        public async void GetAllShowsTest()
        {
            var shows = (ICollection<Show>)await showService.GetAllShows();
            Assert.Equal(301, shows.Count);
        }

        [Fact]
        public async void GetShowsByGenreSearchTest()
        {
            var shows = (ICollection<Show>)await showService.GetShowsByGenreSearch("Comedy|Romance");
            Assert.Equal(39, shows.Count);
        }

        [Fact]
        public async void GetShowsByMovieSearchTest()
        {
            var shows = (ICollection<Show>)await showService.GetShowsByMovieSearch("Born Reckless");
            Assert.Equal(18, shows.Count);
        }

        [Fact]
        public async void GetShowsTodayTest()
        {
            var shows = (ICollection<Show>)await showService.GetShowsToday();
            Assert.Equal(0, shows.Count);
        }

        [Fact]
        public async void ShowExistsTest()
        {
            Movie movie = new Movie("The Two Popes", "At a key turning point for the Catholic Church, Pope Benedict XVI forms a surprising friendship with the future Pope Francis. Inspired by true events.", "Thriller", 125.0, "Anthony Hopkins, Jonathan Pryce, Juan Minujin", "https://cdn.collider.com/wp-content/uploads/2019/07/the-two-popes-anthony-hopkins-jonathan-pryce-1.jpg", "https://www.youtube.com/watch?v=T5OhkFY1PQE");
            CinemaHall cinemaHall = new CinemaHall("SAAL 23", 23, 10);
            Show show = new Show(new DateTime(2020, 11, 26, 12, 33, 48), movie, cinemaHall);
            Assert.False(await showService.ShowExists(show));
        }

        [Fact]
        public async void InsertTest()
        {
            var shows = (ICollection<Show>)await showService.GetAllShows();
            Assert.Equal(301, shows.Count);
            Movie movie = new Movie("The Three Popes", "At a key turning point for the Catholic Church, Pope Benedict XVI forms a surprising friendship with the future Pope Francis. Inspired by true events.", "Thriller", 125.0, "Anthony Hopkins, Jonathan Pryce, Juan Minujin", "https://cdn.collider.com/wp-content/uploads/2019/07/the-two-popes-anthony-hopkins-jonathan-pryce-1.jpg", "https://www.youtube.com/watch?v=T5OhkFY1PQE");
            CinemaHall cinemaHall = new CinemaHall("SAAL 23", 23, 10);
            Show show = new Show(new DateTime(2020, 11, 26, 12, 33, 48), movie, cinemaHall);

            await showService.Insert(show);

            shows = (ICollection<Show>)await showService.GetAllShows();
            Assert.Equal(302, shows.Count);

            //await showService.Delete(show);
        }
    }
}
