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
            Assert.Equal(28, shows.Count);
        }

        [Fact]
        public async void GetShowsByGenreSearchTest()
        {
            var shows = (ICollection<Show>)await showService.GetShowsByGenreSearch("Drama");
            Assert.Equal(39, shows.Count);
        }

        [Fact]
        public async void GetShowsByMovieSearchTest()
        {
            var shows = (ICollection<Show>)await showService.GetShowsByMovieSearch("Emma");
            Assert.Equal(4, shows.Count);
        }

        [Fact]
        public async void GetShowsTodayTest()
        {
            var shows = (ICollection<Show>)await showService.GetShowsToday();
            Assert.Equal(4, shows.Count);
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
        public async void InsertAndDeleteTest()
        {
            var shows = (ICollection<Show>)await showService.GetAllShows();
            Assert.Equal(28, shows.Count);
            Movie movie = new Movie("Bird People", "Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.", "Drama|Fantasy|Romance", 135.87, "Nikki Clyma", "http://dummyimage.com/243x250.bmp/ff4444/ffffff", "https://blinklist.com/consequat.json?sed=tempus&tincidunt=vivamus&eu=in&felis=felis&fusce=eu&posuere=sapien&felis=cursus&sed=vestibulum&lacus=proin&morbi=eu&sem=mi&mauris=nulla&laoreet=ac&ut=enim&rhoncus=in&aliquet=tempor&pulvinar=turpis&sed=nec&nisl=euismod&nunc=scelerisque&rhoncus=quam&dui=turpis&vel=adipiscing&sem=lorem&sed=vitae&sagittis=mattis&nam=nibh&congue=ligula&risus=nec&semper=sem&porta=duis&volutpat=aliquam&quam=convallis&pede=nunc&lobortis=proin&ligula=at&sit=turpis&amet=a&eleifend=pede&pede=posuere&libero=nonummy&quis=integer&orci=non&nullam=velit&molestie=donec&nibh=diam&in=neque&lectus=vestibulum&pellentesque=eget&at=vulputate&nulla=ut&suspendisse=ultrices&potenti=vel&cras=augue&in=vestibulum&purus=ante&eu=ipsum&magna=primis&vulputate=in&luctus=faucibus");
            CinemaHall cinemaHall = new CinemaHall("SAAL 2", 17, 22);
            Show show = new Show(new DateTime(2020, 11, 26, 12, 33, 48), movie, cinemaHall);

            await showService.Insert(show);

            shows = (ICollection<Show>)await showService.GetAllShows();
            Assert.Equal(29, shows.Count);

            await showService.Delete(show);

            shows = (ICollection<Show>)await showService.GetAllShows();
            Assert.Equal(28, shows.Count);
        }
    }
}
