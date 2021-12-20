using Movie.Core.Response;
using Movie.Core.Service.Options;
using Movie.Core.Service.Options.Create;
using Movie.Core.Service.Options.Search;
using Movie.Core.Service.Options.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Service.Interface
{
    public interface IMovieService
    {
        Result<Model.Movie> CreateMovie(CreateMovieOptions options);

        IQueryable<Model.Movie> SearchMovie(SearchMovieOptions options);

        Result<Model.Movie> UpdateMovie(UpdateMovieOptions options);

        Result<Model.Movie> DeleteMovie(int? id);

        IQueryable<Model.Movie> GetById(int? id);
    }
}
