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

        public virtual async Task<bool> DeleteAsync(Movie movie)
        {
            return (await template.ExecuteAsync(
                "DELETE FROM Movie WHERE Title=@tit",
                new QueryParameter("@tit", movie.Title)
                )) == 1;
        }

        public virtual async Task<IEnumerable<Movie>> FindAllAsync()
        {
            return await template.QueryAsync<Movie>("SELECT * FROM Movie", MapRowToMovie);
        }

        public virtual async Task<IEnumerable<Movie>> FindByGenreAsync(string genre)
        {
            return await template.QueryAsync<Movie>(
                "SELECT * FROM Movie WHERE Genre=@genre",
                MapRowToMovie,
                new QueryParameter("@genre", genre));
        }

        public virtual async Task<IEnumerable<Movie>> FindByLengthGreaterAsync(double length)
        {
            return await template.QueryAsync<Movie>(
                "SELECT * FROM Movie WHERE MovieLength>@length",
                MapRowToMovie,
                new QueryParameter("@length", length));
        }

        public virtual async Task<IEnumerable<Movie>> FindByLengthLessAsync(double length)
        {
            return await template.QueryAsync<Movie>(
                "SELECT * FROM Movie WHERE MovieLength<@length",
                MapRowToMovie,
                new QueryParameter("@length", length));
        }

        public virtual async Task<Movie> FindByTitleAsync(string title)
        {
            return await template.QuerySingleAsync<Movie>(
                "SELECT * FROM Movie WHERE Title=@title",
                MapRowToMovie,
                new QueryParameter("@title", title));
        }

        public virtual async Task<bool> InsertAsync(Movie movie)
        {
            return (await template.ExecuteAsync(
                "INSERT INTO Movie (Title, MovieDescription, Genre, MovieLength, Actors, ImageURL, TrailerURL) VALUES (@tit, @md, @gr, @ml, @act, @iu, @tu)",
                new QueryParameter("@tit", movie.Title),
                new QueryParameter("@md", movie.Description),
                new QueryParameter("@gr", movie.Genre),
                new QueryParameter("@ml", movie.Length),
                new QueryParameter("@act", movie.Actors),
                new QueryParameter("@iu", movie.ImageURL),
                new QueryParameter("@tu", movie.TrailerURL)
                )) == 1;
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
