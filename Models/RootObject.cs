using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class RootObject : List<Movie>
    {
        public List<Movie> listOfMovies { get; set; }
    }
}