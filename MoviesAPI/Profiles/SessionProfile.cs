using AutoMapper;
using MoviesAPI.Data.Dtos.Session;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<CreateSessionDto, Session>();
            CreateMap<Session, ReadSessionDto>()
                .ForMember(dto => dto.StartTime, opts => opts
                .MapFrom(dto => dto.FinishTime.AddMinutes(dto.Movie.Duraction * (-1))));
        }
    }
}
