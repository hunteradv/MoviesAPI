using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTeatherController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public MovieTeatherController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovieTeather([FromBody]CreateMovieTeatherDto movieTeatherDto)
        {
            var movieTheater = _mapper.Map<MovieTheater>(movieTeatherDto);

            _context.MovieTheaters.Add(movieTheater);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTeatherById), new {Id = movieTheater.Id}, movieTheater);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeatherById(int id)
        {
            var movieTeather = _context.MovieTheaters.Where(mt => mt.Id == id).FirstOrDefault();

            if(movieTeather is null)
            {
                return NotFound();
            }
            else
            {
                var movieTeatherDto = _mapper.Map<ReadMovieTeatherDto>(movieTeather);

                return Ok(movieTeatherDto);
            }
        }
    }
}
