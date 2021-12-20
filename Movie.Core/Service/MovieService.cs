using Movie.Core.Data;
using Movie.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Service
{
    public class MovieService: IMovieService
    {
        private MovieDbContext context;

        public MovieService(MovieDbContext dbcontext)
        {
            context = dbcontext;
        }
    }
}
