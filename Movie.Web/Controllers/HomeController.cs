using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie.Core.Service.Interface;
using Movie.Core.Service.Options.Search;
using Movie.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMovieService movieService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService_)
        {
            _logger = logger;
            movieService = movieService_;
        }

        public IActionResult Index()
        {
            List<Movie.Core.Model.Movie> featured = movieService.SearchMovie(new SearchMovieOptions { Name=""}).ToList();

            return View(featured);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
