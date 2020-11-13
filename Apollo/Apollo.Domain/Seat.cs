namespace Apollo.Domain
{
    public class Seat
    {
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public SeatCategory SeatCategory { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public Reservation Reservation { get; set; }
    }
}
