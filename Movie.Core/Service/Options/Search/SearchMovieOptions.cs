using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Service.Options.Search
{
    /// <summary>
    /// Search only by name for now, or search all movies if empty name.
    /// </summary>
    public class SearchMovieOptions
    {
        public string Name { get; set; }
    }
}
