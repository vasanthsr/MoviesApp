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
    public class MovieDealsController : Controller
    {
        List<Movie> lstMoviesCinemaWorld;
        List<Movie> lstMoviesFilmWorld;

        public ActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Index(string search)
        {
            //Get Movies from CinemaWorld  & FilmWorld
            lstMoviesCinemaWorld = Common.Common.GetMoviesFromWebAPI("CinemaWorld");
            lstMoviesFilmWorld = Common.Common.GetMoviesFromWebAPI("FilmWorld");

            //Fetch movie from cinema world and film world and check who provides cheapest and retun the object
            Movie searchedMovieCinemaWorld = lstMoviesCinemaWorld.FirstOrDefault(p => p.Title.ToLower().Contains(search.ToLower()));
            Movie searchedMovieFilmWorld = lstMoviesFilmWorld.FirstOrDefault(p => p.Title.ToLower().Contains(search.ToLower()));

            
            Movie cheapestMovieProvider = new Movie();

            if (searchedMovieCinemaWorld != null)
            {
                if (searchedMovieFilmWorld != null)
                {
                    if (searchedMovieCinemaWorld.Price > searchedMovieFilmWorld.Price)
                    {
                        cheapestMovieProvider = searchedMovieFilmWorld;

                    }
                    else
                    {
                        cheapestMovieProvider = searchedMovieCinemaWorld;
                    }

                }
                else
                {
                    cheapestMovieProvider = searchedMovieCinemaWorld;
                }
            }
            else
            {
                cheapestMovieProvider = null;
                ViewData["NoMovie"] = true;
            }

            return View(cheapestMovieProvider);


        }





    }
}
