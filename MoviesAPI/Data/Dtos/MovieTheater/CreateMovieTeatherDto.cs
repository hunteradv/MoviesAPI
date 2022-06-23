using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.MovieTheater
{
    public class CreateMovieTheaterDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
    }
}
