using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
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
        public IActionResult AddMovie([FromBody]CreateMovieDto movieDto)
        {
            var movie = new Movie
            {
                Title = movieDto.Title,
                Genre = movieDto.Genre,
                Duraction = movieDto.Duraction,
                Director = movieDto.Director
            };

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
                ReadMovieDto movieDto = new ReadMovieDto
                {
                    Title = movie.Title,
                    Director = movie.Director,
                    Duraction = movie.Duraction,
                    Id = movie.Id,
                    Genre = movie.Genre,
                    ReadTime = DateTime.Now
                };

                return Ok(movieDto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
        {
            var movie = _context.Movies.Where(m => m.Id == id).FirstOrDefault();

            if(movie == null)
            {
                return NotFound();
            }
            else
            {
                movie.Title = movieDto.Title;
                movie.Genre = movieDto.Genre;
                movie.Duraction = movieDto.Duraction;
                movie.Director = movieDto.Director;

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
