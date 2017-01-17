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
        
        //Handle exceptions 
        [HandleError(ExceptionType = typeof(ArithmeticException), View = "Error")]
        [HandleError(ExceptionType = typeof(ArgumentNullException), View = "Error")]
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "Error")]
        // GET: Movie
        public ActionResult Index(string id, string movieProvider)
        {
            Movie movie = new Movie();
            try
            {
                movie = Common.Common.GetMovieFromWebAPI(id, movieProvider);
            }
            catch(Exception ex)
            {
                return View("Error");
            }
            ViewData["MovieProvider"] = movieProvider;  
            return View(movie);
        }
    }
}