using AutoMapper;
using MoviesAPI.Data.Dtos.Managers;
using MoviesAPI.Models;
using System.Linq;

namespace MoviesAPI.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<Manager, ReadManagerDto>()
                .ForMember(manager => manager.MovieTheaters, opts => opts
                .MapFrom(manager => manager.MovieTheaters.Select
                (mt => new { mt.Id, mt.Name, mt.Address, mt.AddressId })));
            CreateMap<CreateManagerDto, Manager>();
        }
    }
}
