using AutoMapper;
using MoviesAPI.Data.Dtos.Managers;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<Manager, ReadManagerDto>();
            CreateMap<CreateManagerDto, Manager>();
        }
    }
}
