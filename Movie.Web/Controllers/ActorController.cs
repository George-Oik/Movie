using Microsoft.AspNetCore.Mvc;
using Movie.Core.Service.Interface;
using Movie.Core.Service.Options.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Web.Controllers
{
    [Route("actor")]
    public class ActorController : Controller
    {
        private IMovieService movieService;
        private IActorService actorService;

        public ActorController(IMovieService movieService_, IActorService actorService_)
        {
            movieService = movieService_;
            actorService = actorService_;
        }

        /// <summary>
        /// Takes user to the form to create a new actor. Only way to do it for now.
        /// </summary>
        /// <returns></returns>
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Takes submitted actor info and stores them. Returns the result of CreateActor method.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpPost("submit")]
        public IActionResult Submit([FromBody] CreateActorOptions options)
        {
            var result = actorService.CreateActor(options);

            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }

            return Json(result.Data);
        }
    }
}
