using System;

namespace Apollo.Domain
{
    public class Show
    {
        public DateTime StartsAt { get; set; }
        public Movie Movie { get; set; }
        public CinemaHall CinemaHall { get; set; }
    }
}
