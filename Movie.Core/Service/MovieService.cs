using Movie.Core.Data;
using Movie.Core.Model;
using Movie.Core.Response;
using Movie.Core.Service.Interface;
using Movie.Core.Service.Options;
using Movie.Core.Service.Options.Create;
using Movie.Core.Service.Options.Search;
using Movie.Core.Service.Options.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Movie.Core.Service
{
    public class MovieService: IMovieService
    {
        private MovieDbContext context;

        public MovieService(MovieDbContext dbcontext)
        {
            context = dbcontext;
        }

        /// <summary>
        /// Create movie from user input. Also store the images' and videos' URLs. Only store actors info if he exists in database.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Result<Model.Movie> CreateMovie(CreateMovieOptions options)
        {
            if (options == null)
            {
                return new Result<Model.Movie>()
                {
                    Data = null,
                    ErrorCode = StatusCode.BadRequest,
                    ErrorText = "No info provided"
                };
            }

            if (string.IsNullOrWhiteSpace(options.Name))
            {
                return new Result<Model.Movie>()
                {
                    Data = null,
                    ErrorCode = StatusCode.BadRequest,
                    ErrorText = "No movie name provided"
                };
            }

            Model.Movie movie = new Model.Movie();

            movie.Name = options.Name;

            if (string.IsNullOrWhiteSpace(options.Plot))
            {
                movie.Plot = "No information published.";
            }
            else
            {
                movie.Plot = options.Plot;
            }

            if (string.IsNullOrWhiteSpace(options.ReleaseDate))
            {
                movie.ReleaseDate = "TBA";
            }
            else
            {
                movie.ReleaseDate = options.ReleaseDate;
            }

            //Actors are searched for in the database, and added in the list only if found. Else nothing is added.
            if (options.Cast != null && options.Cast.Count > 0)
            {
                foreach (MovieActor mActor in options.Cast)
                {
                    if (string.IsNullOrWhiteSpace(mActor.Actor.FirstName) ||
                        string.IsNullOrWhiteSpace(mActor.Actor.LastName))
                    {
                        continue;
                    }

                    var Actor = context
                                .Set<Actor>()
                                    .Where(x => x.FirstName == mActor.Actor.FirstName &&
                                                    x.LastName == mActor.Actor.LastName)
                                        .SingleOrDefault();

                    if (Actor != null)
                    {
                        var movieactor = new MovieActor()
                        {
                            Actor= Actor,
                            Role = mActor.Role
                        };

                        movie.Cast.Add(movieactor);
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(options.Poster))
            {
                movie.Poster = "No info";
            }
            else
            {
                movie.Poster = options.Poster;
            }

            //The images that are not null are created and added to the list.
            if (options.Images != null && options.Images.Count > 0)
            {
                foreach (var pic in options.Images)
                {
                    if (string.IsNullOrWhiteSpace(pic.Link))
                    {
                        continue;
                    }

                    var image = new Image()
                    {
                        Link = pic.Link,
                        Title = pic.Title,
                    };

                    movie.Images.Add(image);
                }
            }

            if (!string.IsNullOrWhiteSpace(options.Trailer))
            {
                movie.Trailer = options.Trailer;
            }

            if (string.IsNullOrWhiteSpace(options.Genre))
            {
                movie.Genre = "Unknown";
            }
            else
            {
                movie.Genre = options.Genre;
            }

            context.Add(movie);

            var rows = 0;

            try
            {
                rows = context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result<Model.Movie>.ActionFailed(
                    StatusCode.InternalServerError, ex.ToString());
            }

            if (rows <= 0)
            {
                return Result<Model.Movie>.ActionFailed(
                    StatusCode.InternalServerError,
                    "Movie could not be added");
            }

            return Result<Model.Movie>.ActionSuccessful(movie);
        }

        /// <summary>
        /// Remove a movie from the database, along with its images and MovieActor relation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Result<Model.Movie> DeleteMovie(int? id)
        {
            if (id == null || id == 0)
            {
                return new Result<Model.Movie>()
                {
                    Data = null,
                    ErrorCode = StatusCode.BadRequest,
                    ErrorText = "Bad info provided"
                };
            }

            var movie = GetById(id)
                    .Include(z => z.Cast)
                    .Include(y => y.Images)
                    .SingleOrDefault();

            if(movie == null)
            {
                return new Result<Model.Movie>()
                {
                    Data = null,
                    ErrorCode = StatusCode.NotFound,
                    ErrorText = "Movie not found"
                };
            }

            context.Remove(movie);

            var rows = 0;

            try
            {
                rows = context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result<Model.Movie>.ActionFailed(
                    StatusCode.InternalServerError, ex.ToString());
            }

            if (rows <= 0)
            {
                return Result<Model.Movie>.ActionFailed(
                    StatusCode.InternalServerError,
                    "Movie deleted");
            }

            return Result<Model.Movie>.ActionSuccessful(movie);
        }

        /// <summary>
        /// Get movie by its database Id and include all info from the related tables.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<Model.Movie> GetById(int? id)
        {
            if (id == null || id == 0)
            {
                return null;
            }

            return context.Set<Model.Movie>()
                    .Where(x => x.MovieId == id)
                        .Include(z => z.Images)
                            .Include(y=>y.Cast)
                                .ThenInclude(o=>o.Actor)
                                    .AsQueryable();
        }

        /// <summary>
        /// Search only by name for now, or search all movies if empty name. 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public IQueryable<Model.Movie> SearchMovie(SearchMovieOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Name))
            {
                return context.Set<Model.Movie>().AsQueryable();
            }

            return context.Set<Model.Movie>()
                    .Where(x => x.Name.Contains(options.Name)).AsQueryable();
        }

        /// <summary>
        /// Update movie from user's given info. Not yet implemented in front end.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Result<Model.Movie> UpdateMovie(UpdateMovieOptions options)
        {
            if (options==null || options.MovieId == null || options.MovieId == 0)
            {
                return Result<Model.Movie>.ActionFailed(
                    StatusCode.BadRequest,
                    "Bad info provided");
            }

            var movie = GetById(options.MovieId)
                    .Include(z => z.Cast)
                    .Include(y => y.Images)
                    .SingleOrDefault();

            if (movie == null)
            {
                return Result<Model.Movie>.ActionFailed(
                    StatusCode.NotFound,
                    "Movie not found");
            }

            if (!string.IsNullOrWhiteSpace(options.Plot))
            {
                movie.Plot = options.Plot;
            }

            if (!string.IsNullOrWhiteSpace(options.ReleaseDate))
            {
                movie.ReleaseDate = options.ReleaseDate;
            }

            if (options.Cast != null && options.Cast.Count > 0)
            {
                foreach (MovieActor mActor in options.Cast)
                {
                    if (movie.Cast.Contains(mActor))
                    {
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(mActor.Actor.FirstName) ||
                        string.IsNullOrWhiteSpace(mActor.Actor.LastName))
                    {
                        continue;
                    }

                    var Actor = context
                                .Set<Actor>()
                                    .Where(x => x.FirstName == mActor.Actor.FirstName &&
                                                    x.LastName == mActor.Actor.LastName)
                                        .SingleOrDefault();

                    if (Actor != null)
                    {
                        var movieactor = new MovieActor()
                        {
                            Actor = mActor.Actor,
                            Role = mActor.Role
                        };

                        movie.Cast.Add(movieactor);
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(options.Poster))
            {
                movie.Poster = options.Poster;
            }

            if (options.Images != null && options.Images.Count > 0)
            {
                foreach (var pic in options.Images)
                {
                    if (string.IsNullOrWhiteSpace(pic.Link))
                    {
                        continue;
                    }

                    if (movie.Images.Contains(pic))
                    {
                        continue;
                    }

                    var image = new Image()
                    {
                        Link = pic.Link,
                        Title = pic.Title,
                    };

                    movie.Images.Add(image);
                }
            }

            if (!string.IsNullOrWhiteSpace(options.Trailer))
            {
                movie.Trailer = options.Trailer;
            }

            if (!string.IsNullOrWhiteSpace(options.Genre))
            {
                movie.Genre = options.Genre;
            }

            context.Add(movie);

            var rows = 0;

            try
            {
                rows = context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Result<Model.Movie>.ActionFailed(
                    StatusCode.InternalServerError, ex.ToString());
            }

            if (rows <= 0)
            {
                return Result<Model.Movie>.ActionFailed(
                    StatusCode.InternalServerError,
                    "Movie could not be updated");
            }

            return Result<Model.Movie>.ActionSuccessful(movie);
        }
    }
}
