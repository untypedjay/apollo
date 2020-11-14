using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class MovieDao : IMovieDao
    {
        protected abstract string LastInsertTitleQuery { get; }
        private readonly AdoTemplate template;

        public MovieDao(IConnectionFactory connectionFactory)
        {
            template = new AdoTemplate(connectionFactory);
        }

        public Task<bool> DeleteAsync(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<IEnumerable<Movie>> FindAllAsync()
        {
            return await template.QueryAsync<Movie>("SELECT * FROM Movie", MapRowToMovie);
        }

        public Task<IEnumerable<Movie>> FindByGenreAsync(string genre)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Movie>> FindByLengthGreaterAsync(double length)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Movie>> FindByLengthLessAsync(double length)
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> FindByTitleAsync(string title)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertAsync(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<bool> UpdateAsync(Movie movie)
        {
            return (await template.ExecuteAsync(
                "UPDATE Movie SET MovieDescription=@md, Genre=@gr, MovieLength=@ml, Actors=@act, ImageURL=@iu, TrailerURL@tu WHERE Title=@tit",
                new QueryParameter("@md", movie.Description),
                new QueryParameter("@gr", movie.Genre),
                new QueryParameter("@ml", movie.Length),
                new QueryParameter("@act", movie.Actors),
                new QueryParameter("@iu", movie.ImageURL),
                new QueryParameter("@tu", movie.TrailerURL)
                )) == 1;
        }

        private Movie MapRowToMovie(IDataRecord row)
        {
            return new Movie
            {
                Title = (string)row["Title"],
                Description = (string)row["MovieDescription"],
                Genre = (string)row["Genre"],
                Length = (double)row["MovieLength"],
                Actors = (string)row["Actors"],
                ImageURL = (string)row["ImageURL"],
                TrailerURL = (string)row["TrailerURL"]
            };
        }
    }
}
