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

        [Fact]
        public async void InsertAsyncTest()
        {
            Assert.Equal(0, 1);
        }

        [Fact]
        public async void FindAllAsyncTest()
        {
            IConfiguration config = ConfigurationUtil.GetConfiguration(BaseDirectory);
            IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration(config, "ApolloTestDbConnection");

            IMovieDao movieDao = new MSSQLMovieDao(connectionFactory);

            ICollection<Movie> movies = (ICollection<Movie>) await movieDao.FindAllAsync();
            Assert.Equal(101, movies.Count);
        }

        [Fact]
        public async void FindByTitleAsyncTest()
        {
            Assert.Equal(0, 1);
        }

        [Fact]
        public async void FindByGenreAsyncTest()
        {
            Assert.Equal(0, 1);
        }

        [Fact]
        public async void FindByLengthGreaterAsyncTest()
        {
            Assert.Equal(0, 1);
        }

        [Fact]
        public async void FindByLengthLessAsyncTest()
        {
            Assert.Equal(0, 1);
        }

        [Fact]
        public async void UpdateAsyncTest()
        {
            Assert.Equal(0, 1);
        }

        [Fact]
        public async void DeleteAsyncTest()
        {
            Assert.Equal(0, 1);
        }
    }
}