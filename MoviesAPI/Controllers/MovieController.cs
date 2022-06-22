using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
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
        private MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody]Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new {Id = movie.Id}, movie);            
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies;
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _context.Movies.Where(m => m.Id == id).FirstOrDefault();

            if(movie != null)
            {
                return Ok(movie);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie newMovie)
        {
            var movie = _context.Movies.Where(m => m.Id == id).FirstOrDefault();

            if(movie == null)
            {
                return NotFound();
            }
            else
            {
                movie.Title = newMovie.Title;
                movie.Genre = newMovie.Genre;
                movie.Duraction = newMovie.Duraction;
                movie.Director = newMovie.Director;

                _context.SaveChanges();

                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Where(m => m.Id == id).FirstOrDefault();
            if(movie == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(movie);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
