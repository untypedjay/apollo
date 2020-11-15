using System;

namespace Apollo.Domain
{
    public class Show
    {
        public DateTime StartsAt { get; set; }
        public Movie Movie { get; set; }
        public CinemaHall CinemaHall { get; set; }

        public Show(DateTime startsAt, Movie movie, CinemaHall cinemaHall)
        {
            StartsAt = startsAt;
            Movie = movie;
            CinemaHall = cinemaHall;
        }
    }
}
