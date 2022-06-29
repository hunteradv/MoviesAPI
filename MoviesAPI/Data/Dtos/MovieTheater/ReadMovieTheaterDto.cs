using MoviesAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.MovieTheaters
{
    public class ReadMovieTheaterDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
        public DateTime ReadTime { get; set; }
        public Address Address { get; set; }
        public Manager Manager { get; set; }
    }
}
