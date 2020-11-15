namespace Apollo.Domain
{
    public class Reservation
    {
        public long Id { get; set; }
        public int MaxSeats { get; set; }
        public Show Show { get; set; }

        public Reservation(long id, int maxSeats, Show show)
        {
            Id = id;
            MaxSeats = maxSeats;
            Show = show;
        }
    }
}