using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Managers;
using MoviesAPI.Models;
using System;
using System.Collections;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ManagerController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddManager([FromBody] CreateManagerDto dto)
        {
            var manager = _mapper.Map<Manager>(dto);

            _context.Managers.Add(manager);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetManagerById), new { manager.Id }, manager);
        }

        [HttpGet]
        public IEnumerable GetManager()
        {
            return _context.Managers;
        }

        [HttpGet("{id}")]
        public IActionResult GetManagerById(int id)
        {
            var manager = _context.Managers.Where(m => m.Id == id).FirstOrDefault();

            if(manager is null)
            {
                return NotFound();
            }
            else
            {
                var managerDto = _mapper.Map<ReadManagerDto>(manager);               

                return Ok(managerDto);
            }
        }

        [HttpDelete]
        public IActionResult DeleteManager(int id)
        {
            var manager = _context.Managers.Where(m => m.Id == id).FirstOrDefault();

            if(manager is null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(manager);
                _context.SaveChanges();

                return NoContent();
            }
        }
    }
}
