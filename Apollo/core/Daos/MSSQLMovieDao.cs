namespace Apollo.Core.Daos
{
    public class MSSQLMovieDao : MovieDao
    {
        public MSSQLMovieDao(IConnectionFactory connectionFactory) : base(connectionFactory) { }

        protected override string LastInsertTitleQuery => "SELECT scope_identity()";
    }
}
