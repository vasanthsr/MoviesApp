using Movies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Movies.Common
{
    public static class Common
    {
        //Common functions that can be reused
        public static List<Movie> GetMoviesFromWebAPI(string movieProvider)
        {
            List<Movie> lstMovies = new List<Movie>();
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://webjetapitest.azurewebsites.net/"); //webapi provided by webjet as sample
                //client.BaseAddress = new Uri("http://localhost:62359/");
                client.BaseAddress = new Uri("http://alertvmprod.cloudapp.net/MoviesWebApi/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("x-access-token", "sjd1HfkjU83ksdsm3802k"); //access token provided by webjet to access the sample
                var response = client.GetAsync("api/" + movieProvider + "movies").Result;
                if (response.IsSuccessStatusCode)
                {

                    var responseData = response.Content.ReadAsStringAsync().Result;
                    var moviesList = JsonConvert.DeserializeObject<List<Movie>>(responseData); //Deserialize the object and assign to List
                    foreach (var item in moviesList)
                    {
                        Movie movie = new Movie();
                        item.MovieProvider = movieProvider;
                    }
                    lstMovies = moviesList;
                }
            }
            return lstMovies;
        }
    }
}