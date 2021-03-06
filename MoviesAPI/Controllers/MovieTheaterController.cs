using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.MovieTheaters;
using MoviesAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTheaterController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public MovieTheaterController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovieTeather([FromBody]CreateMovieTheaterDto movieTheaterDto)
        {
            var movieTheater = _mapper.Map<MovieTheater>(movieTheaterDto);

            _context.MovieTheaters.Add(movieTheater);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieTheater), new {Id = movieTheater.Id}, movieTheater);
        }

        [HttpGet]
        public IActionResult GetMovieTheater([FromQuery] string movieName)
        {
            var movieTheaters = _context.MovieTheaters.ToList();
            if(movieTheaters is null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(movieName))
            {
                var query = from movieTheater in movieTheaters 
                            where movieTheater.Sessions.Any(session => session.Movie.Title == movieName) 
                            select movieTheater;

                movieTheaters = query.ToList();
            }

            var readDto = _mapper.Map<List<ReadMovieTheaterDto>>(movieTheaters);
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieTheater(int id)
        {
            var movieTheater = _context.MovieTheaters.Where(mt => mt.Id == id).FirstOrDefault();

            if(movieTheater is null)
            {
                return NotFound();
            }
            else
            {
                var movieTheaterDto = _mapper.Map<ReadMovieTheaterDto>(movieTheater);
                return Ok(movieTheaterDto);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovieTheater([FromBody]UpdateMovieTheaterDto movieTheaterDto, int id)
        {
            var movieTheater = _context.MovieTheaters.Where(mt => mt.Id == id).FirstOrDefault();

            if(movieTheater is null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(movieTheaterDto, movieTheater);
                _context.SaveChanges();

                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovieTheater(int id)
        {
            var movieTheater = _context.MovieTheaters.Where(mt => mt.Id == id).FirstOrDefault();

            if(movieTheater is null)
            {
                return NotFound();
            }
            else
            {
                _context.MovieTheaters.Remove(movieTheater);
                _context.SaveChanges();

                return NoContent();
            }
        }
    }
}
