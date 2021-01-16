using Apollo.Core.Services;
using Apollo.Domain;
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
            Assert.Equal(8, shows.Count);
        }
    }
}
