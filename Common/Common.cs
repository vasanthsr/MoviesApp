using Movies.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                client.BaseAddress = new Uri("http://webjetapitest.azurewebsites.net/"); //webapi provided by webjet as sample
                
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-access-token", "sjd1HfkjU83ksdsm3802k"); //access token provided by webjet to access the sample
                var response = client.GetAsync("api/" + movieProvider + "/movies").Result;
                if (response.IsSuccessStatusCode)
                {
   
                    //Read response content result into string variable
                    var strJson = response.Content.ReadAsStringAsync().Result;

                    var moviesList = JObject.Parse(strJson).SelectToken("Movies").ToObject<List<Movie>>();

                    foreach (var item in moviesList)
                    {
                        Movie movie = new Movie();
                        item.MovieProvider = movieProvider;
                        //Assumption - Set price for movies as API did not have price
                        
                        switch (movieProvider)
                        {
                            case "FilmWorld":
                                {
                                    item.Price = 5;
                                    break;
                                }
                            case "CinemaWorld":
                                {
                                    item.Price = 4;
                                    break;
                                }
                            default:
                                {
                                    item.Price = 6;
                                    break;
                                }
                        }
                        
                    }
                    

                    
                    lstMovies = moviesList;
                }
            }
            return lstMovies;
        }

        public static Movie GetMovieFromWebAPI(string id, string movieProvider)
        {
            Movie reqMovie = new Movie();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://webjetapitest.azurewebsites.net/"); //webapi provided by webjet as sample

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-access-token", "sjd1HfkjU83ksdsm3802k"); //access token provided by webjet to access the sample
                var response = client.GetAsync("api/" + movieProvider + "/movie/" + id).Result;
                if (response.IsSuccessStatusCode)
                {

                    //Read response content result into string variable
                    var strJson = response.Content.ReadAsStringAsync().Result;

                    reqMovie = JsonConvert.DeserializeObject<Movie>(strJson);

                    reqMovie.MovieProvider = movieProvider;
                    switch (movieProvider)
                    {
                        case "FilmWorld":
                            {
                                reqMovie.Price = 5;
                                break;
                            }
                        case "CinemaWorld":
                            {
                                reqMovie.Price = 4;
                                break;
                            }
                        default:
                            {
                                reqMovie.Price = 6;
                                break;
                            }
                    }



                }
            }
            return reqMovie;
        }
    }
}