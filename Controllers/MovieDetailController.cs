using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class MovieDetailController : Controller
    {
        // GET: Movie
        
        public ActionResult Index(string id, string movieProvider)
        {
            Movie movie = new Movie();
            movie = Common.Common.GetMovieFromWebAPI(id, movieProvider);
            
            return View(movie);
        }
    }
}