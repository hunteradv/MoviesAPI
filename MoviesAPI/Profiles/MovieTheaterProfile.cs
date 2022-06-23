using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<CreateMovieDto, MovieTheater>();
            CreateMap<UpdateMovieDto, MovieTheater>();
            CreateMap<MovieTheater, ReadMovieDto>();
        }
    }
}
