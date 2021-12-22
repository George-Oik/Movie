using Movie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Service.Options.Update
{
    public class UpdateMovieOptions
    {
        public int? MovieId { get; set; } //This is not updated, it is only to search for the movie.
        public string Plot { get; set; }
        public string ReleaseDate { get; set; }
        public List<MovieActor> Cast { get; set; }
        public string Poster { get; set; }
        public List<Image> Images { get; set; }
        public string Trailer { get; set; }
        public string Genre { get; set; }
    }
}
