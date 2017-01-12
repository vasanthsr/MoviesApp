using Movies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    //Handle exceptions 
    [HandleError(ExceptionType = typeof(ArithmeticException), View = "Error")]
    [HandleError(ExceptionType = typeof(ArgumentNullException), View = "Error")]
    [HandleError(ExceptionType = typeof(NullReferenceException), View = "Error")]
    public class CinemaWorldMoviesController : Controller
    {
        //Fetch all movies provided by CinemaWorld
        public ActionResult Index()
        {
            
            List<Movie> lstMovies = new List<Movie>();
            lstMovies = Common.Common.GetMoviesFromWebAPI("CinemaWorld");
            return View(lstMovies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
    }
}
