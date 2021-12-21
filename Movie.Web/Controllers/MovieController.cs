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

        [HttpGet("index")]
        public IActionResult Create()
        {
            return View();
        }

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

        [HttpGet("remove/{id}")]
        public LocalRedirectResult Remove(int id)
        {
            var result = movieService.DeleteMovie(id);

            return LocalRedirect("/Home/Index");
        }

        [HttpGet("moviePage/{id}")]
        public IActionResult MoviePage(int id)
        {
            var movie = movieService.GetById(id).FirstOrDefault();

            return View(movie);
        }
    }
}
