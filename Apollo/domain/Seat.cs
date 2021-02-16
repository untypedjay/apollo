namespace Apollo.Domain
{
    public class Seat
    {
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public SeatCategory SeatCategory { get; set; }

        public Seat(int seatNumber, int rowNumber, CinemaHall cinemaHall, SeatCategory seatCategory)
        {
            SeatNumber = seatNumber;
            RowNumber = rowNumber;
            CinemaHall = cinemaHall;
            SeatCategory = seatCategory;
        }
    }
}
