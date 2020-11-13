namespace Apollo.Domain
{
    public class Reservation
    {
        public long Id { get; set; }
        public int MaxSeats { get; set; }
        public Show Show { get; set; }
    }
}
