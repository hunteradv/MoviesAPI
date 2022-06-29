using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Addresses;
using MoviesAPI.Models;
using System;
using System.Collections;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class AddressController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AddressController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] CreateAddressDto createAddressDto)
        {
            var address = _mapper.Map<Address>(createAddressDto);

            _context.Add(address);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAddressById), new { address.Id }, address);
        }

        [HttpGet]
        public IEnumerable GetAddress()
        {
            return _context.Addresses;
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            var address = _context.Addresses.Where(a => a.Id == id).FirstOrDefault();

            if(address is null)
            {
                return NotFound();
            }
            else
            {
                var addressDto = _mapper.Map<ReadAddressDto>(address);

                return Ok(addressDto);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress([FromBody]UpdateAddressDto updateAddressDto, int id)
        {
            var address = _context.Addresses.Where(a => a.Id == id).FirstOrDefault();

            if(address is null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(updateAddressDto, address);
                _context.SaveChanges();

                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            var address = _context.Addresses.Where(a => a.Id == id).FirstOrDefault();

            if(address is null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(address);
                _context.SaveChanges();

                return NoContent();
            }
        }
    }
}
