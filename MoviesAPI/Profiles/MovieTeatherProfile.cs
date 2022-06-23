using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class MovieTeatherProfile : Profile
    {
        public MovieTeatherProfile()
        {
            CreateMap<CreateMovieDto, MovieTheater>();
            CreateMap<UpdateMovieDto, MovieTheater>();
            CreateMap<MovieTheater, ReadMovieDto>();
        }
    }
}
