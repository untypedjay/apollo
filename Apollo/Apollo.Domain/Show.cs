using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain
{
    class Show
    {
        public DateTime Date { get; set; }
        public Movie Movie { get; set; }
        public CinemaHall CinemaHall { get; set; }
    }
}
