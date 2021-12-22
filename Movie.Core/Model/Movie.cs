using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Model
{
    /// <summary>
    /// Movie contains MovieActor class instead of Actor, as Movie and Actor have a lot to lot relationship.
    /// One movie has many actors and an actor plays in many movies.
    /// </summary>
    public class Movie
    {
        public Movie()
        {
            Cast = new List<MovieActor>();
            Images = new List<Image>();
        }

        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public string ReleaseDate { get; set; } //This is string to be able to write "TBA" in case no date is given.
        public List<MovieActor> Cast { get; set; }
        public string Poster { get; set; }
        public List<Image> Images { get; set; }
        public string Trailer { get; set; }
        public string Genre { get; set; }
    }
}
