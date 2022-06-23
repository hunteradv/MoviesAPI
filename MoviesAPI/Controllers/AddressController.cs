using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;

namespace MoviesAPI.Controllers
{
    public class AddressController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AddressController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
