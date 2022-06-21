using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();

        [HttpPost]
        public void AddMovie([FromBody]Movie movie)
        {
            movies.Add(movie);
        }

        //[HttpGet]
        //public Movie GetMovie()
        //{
        //    return movies.ToString;
        //}
    }
}
