namespace Apollo.Domain
{
    public class CinemaHall
    {
        public string Name { get; set; }
        public int RowAmount { get; set; }
        public int SeatAmount { get; set; }

        public CinemaHall(string name, int rowAmount, int seatAmount)
        {
            Name = name;
            RowAmount = rowAmount;
            SeatAmount = seatAmount;
        }

    }
}
