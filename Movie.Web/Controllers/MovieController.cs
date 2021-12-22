using Microsoft.AspNetCore.Mvc;
using Movie.Core.Service;
using Movie.Core.Service.Interface;
using Movie.Core.Service.Options.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Web.Controllers
{
    [Route("movie")]
    public class MovieController : Controller
    {
        private IMovieService movieService;

        public MovieController(IMovieService movieService_)
        {
            movieService = movieService_;
        }

        /// <summary>
        /// Takes user to a form to input the movie's info.
        /// </summary>
        /// <returns></returns>
        [HttpGet("index")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Takes the submited form's info and returns the result from the CreateMovie method.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpPost("submit")]
        public IActionResult Submit([FromBody]CreateMovieOptions options)
        {
            var result = movieService.CreateMovie(options);

            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }

            return Json(result.Data);
        }

        /// <summary>
        /// Removes a movie from database. Implemented as Get and not Delete because of the simplicity of the request. Will be re-written.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("remove/{id}")]
        public LocalRedirectResult Remove(int id)
        {
            var result = movieService.DeleteMovie(id);

            return LocalRedirect("/Home/Index");
        }

        /// <summary>
        /// Get's a movie by its Id on user click, with all info, and takes him to the movie page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("moviePage/{id}")]
        public IActionResult MoviePage(int id)
        {
            var movie = movieService.GetById(id).FirstOrDefault();

            return View(movie);
        }
    }
}
