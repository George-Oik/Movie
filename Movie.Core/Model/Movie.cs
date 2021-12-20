using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Model
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public DateTimeOffset ReleaseYear { get; set; }
        public List<MovieActor> Cast { get; set; }
        public string Poster { get; set; }
        public List<Image> Images { get; set; }
        public string Trailer { get; set; }
        public string Genre { get; set; }
    }
}
