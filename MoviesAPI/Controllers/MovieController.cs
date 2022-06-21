﻿using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AddMovie([FromBody]Movie movie)
        {
            movie.Id = id++;
            movies.Add(movie);
            return CreatedAtAction(nameof(GetMovieById), new {Id = movie.Id}, movie);
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = movies.Where(m => m.Id == id).FirstOrDefault();

            if(movie != null)
            {
                return Ok(movie);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
