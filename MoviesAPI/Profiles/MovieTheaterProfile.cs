using AutoMapper;
using MoviesAPI.Data.Dtos.Movie;
using MoviesAPI.Data.Dtos.MovieTheaters;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<CreateMovieTheaterDto, MovieTheater>();
            CreateMap<UpdateMovieTheaterDto, MovieTheater>();
            CreateMap<MovieTheater, ReadMovieTheaterDto>();
        }
    }
}
