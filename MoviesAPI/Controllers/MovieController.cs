using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Movies;
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
        private AppDbContext _context;
        private IMapper _mapper;

        public MovieController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody]CreateMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new {Id = movie.Id}, movie);            
        }

        [HttpGet]
        public IActionResult GetMovies([FromQuery] int? ageRating = null)
        {
            var movies = new List<Movie>();

            if (ageRating is null)
            {
                movies = _context.Movies.ToList();
            }
            else
            {
                movies = _context.Movies.Where(m => m.AgeRating <= ageRating).ToList();
            }
          
            if(movies is null)
            {
                return NotFound();
            }
            else
            {
                var dto = _mapper.Map<List<ReadMovieDto>>(movies);
                return Ok(dto);
            }            
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _context.Movies.Where(m => m.Id == id).FirstOrDefault();

            if(movie is null)
            {
                return NotFound();
            }
            else
            {
                ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);

                return Ok(movieDto);
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
                _mapper.Map(movieDto, movie);

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
