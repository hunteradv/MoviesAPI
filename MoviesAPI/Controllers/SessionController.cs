using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Session;
using MoviesAPI.Models;
using System;
using System.Collections;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessionController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSession([FromBody] CreateSessionDto dto)
        {
            var session = _mapper.Map<Session>(dto);

            _context.Add(session);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSessionById), new { session.Id }, session);
        }

        [HttpGet]
        public IEnumerable GetSession()
        {
            return _context.Sessions;
        }

        [HttpGet("{id}")]
        public IActionResult GetSessionById(int id)
        {
            var session = _context.Sessions.Where(s => s.Id == id).FirstOrDefault();

            if(session is null)
            {
                return NotFound();
            }
            else
            {
                var sessionDto = _mapper.Map<ReadSessionDto>(session);
                return Ok(sessionDto);
            }
        }
    }
}
