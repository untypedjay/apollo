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
        public async void FindAllAsyncTest()
        {
            IConfiguration config = ConfigurationUtil.GetConfiguration(BaseDirectory);
            IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration(config, "ApolloTestDbConnection");

            IMovieDao movieDao = new MSSQLMovieDao(connectionFactory);

            ICollection<Movie> movies = (ICollection<Movie>) await movieDao.FindAllAsync();
            Assert.Equal(101, movies.Count);
        }
    }
}
