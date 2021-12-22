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
        /// <summary>
        /// Create movie from user input. Also store the images' and videos' URLs. Only store actors info if he exists in database.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Result<Model.Movie> CreateMovie(CreateMovieOptions options);

        /// <summary>
        /// Search only by name for now, or search all movies if empty name. 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        IQueryable<Model.Movie> SearchMovie(SearchMovieOptions options);

        /// <summary>
        /// Update movie from user's given info. Not yet implemented in front end.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Result<Model.Movie> UpdateMovie(UpdateMovieOptions options);

        /// <summary>
        /// Remove a movie from the database, along with its images and MovieActor relation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Result<Model.Movie> DeleteMovie(int? id);

        /// <summary>
        /// Get movie by its database Id and include all info from the related tables.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<Model.Movie> GetById(int? id);
    }
}
