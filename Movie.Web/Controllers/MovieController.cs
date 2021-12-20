using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Web.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        public IActionResult Remove()
        {
            throw new NotImplementedException();
        }

        public IActionResult Update()
        {
            throw new NotImplementedException();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult MoviePage()
        {
            return View();
        }
    }
}
