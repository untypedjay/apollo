using Apollo.Core.Daos;
using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Apollo.Core.Test
{
    public class MovieDaoTests
    {
        static string BaseDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\";
        static IConfiguration config = ConfigurationUtil.GetConfiguration(BaseDirectory);
        static IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration(config, "ApolloTestDbConnection");
        IMovieDao movieDao = new MSSQLMovieDao(connectionFactory);

        [Fact]
        public async void InsertAsyncTest()
        {
            Movie newMovie = new Movie("Aladdin", "A great movie.", "Animation", 120.05, "Actor 1, Actor 2", "http://dummyimage.com/218x211.png/5fa2dd/ffffff", "https://gov.uk/sem/duis/aliquam/convallis.json?dapibus=magna&nulla=ac&suscipit=consequat&ligula=metus&in=sapien&lacus=ut&curabitur=nunc&at=vestibulum&ipsum=ante");
            Assert.True(await movieDao.InsertAsync(newMovie));
            await movieDao.DeleteAsync(newMovie);
        }

        [Fact]
        public async void FindAllAsyncTest()
        {
            ICollection<Movie> movies = (ICollection<Movie>) await movieDao.FindAllAsync();
            Assert.Equal(101, movies.Count);
        }

        [Fact]
        public async void FindByTitleAsyncTest()
        {
            Movie movie = await movieDao.FindByTitleAsync("Kokowääh");
            Assert.Equal("Kokowääh", movie.Title);
        }

        [Fact]
        public async void FindByGenreAsyncTest()
        {
            ICollection<Movie> movies = (ICollection<Movie>)await movieDao.FindByGenreAsync("Comedy");
            Assert.Equal(11, movies.Count);
        }

        [Fact]
        public async void FindByLengthGreaterAsyncTest()
        {
            ICollection<Movie> movies = (ICollection<Movie>)await movieDao.FindByLengthGreaterAsync(90.6);
            Assert.Equal(80, movies.Count);
        }

        [Fact]
        public async void FindByLengthLessAsyncTest()
        {
            ICollection<Movie> movies = (ICollection<Movie>)await movieDao.FindByLengthLessAsync(65.33);
            Assert.Equal(3, movies.Count);
        }

        [Fact]
        public async void UpdateAsyncTest()
        {
            Movie movie = new Movie("The Two Popes", "At a key turning point for the Catholic Church, Pope Benedict XVI forms a surprising friendship with the future Pope Francis. Inspired by true events.", "Thriller", 125.0, "Anthony Hopkins, Jonathan Pryce, Juan Minujin", "https://cdn.collider.com/wp-content/uploads/2019/07/the-two-popes-anthony-hopkins-jonathan-pryce-1.jpg", "https://www.youtube.com/watch?v=T5OhkFY1PQE");
            Movie result = await movieDao.FindByTitleAsync("The Two Popes");
            Assert.NotEqual(movie.Genre, result.Genre);
            Assert.True(await movieDao.UpdateAsync(movie));
            Movie result2 = await movieDao.FindByTitleAsync("The Two Popes");
            Assert.Equal(movie.Genre, result2.Genre);
            Assert.True(await movieDao.UpdateAsync(result));
            Movie result3 = await movieDao.FindByTitleAsync("The Two Popes");
            Assert.NotEqual(movie.Genre, result3.Genre);
        }

        [Fact]
        public async void DeleteAsyncTest()
        {
            Movie movie = new Movie("Aladdin", "A great movie.", "Animation", 120.05, "Actor 1, Actor 2", "http://dummyimage.com/218x211.png/5fa2dd/ffffff", "https://gov.uk/sem/duis/aliquam/convallis.json?dapibus=magna&nulla=ac&suscipit=consequat&ligula=metus&in=sapien&lacus=ut&curabitur=nunc&at=vestibulum&ipsum=ante");
            await movieDao.InsertAsync(movie);
            Assert.True(await movieDao.DeleteAsync(movie));
        }
    }
}