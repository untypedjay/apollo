using System;

namespace Apollo.Domain
{
    public class Movie
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public double Length { get; set; }
        public string Actors { get; set; }
        public string ImageURL { get; set; }
        public string TrailerURL { get; set; }
    }
}
