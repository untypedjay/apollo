namespace Apollo.Core.Daos
{
    public class MSSQLReservationDao : ReservationDao
    {
        public MSSQLReservationDao(IConnectionFactory connectionFactory) : base(connectionFactory) { }

        protected override string LastInsertIdQuery => "SELECT scope_identity()";
    }
}
