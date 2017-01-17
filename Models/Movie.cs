using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Movie
    {
        //public Movie(string json)
        //{
        //    JObject jObject = JObject.Parse(json);
        //    JToken jMovies = jObject["Movies"];
        //    Id = (string)jMovies["ID"];
        //    Title = (string)jMovies["Title"];
        //    Year = (string)jMovies["Year"];
            
        //}


        public string Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }

        public decimal? Price { get; set; }

        public string MovieProvider { get; set; }

        //public string Category { get; set; }
        //public decimal Price { get; set; }


        public string Rating { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Language { get; set; }
        //public string Director { get; set; }
        public string Plot { get; set; }
        
    }
}