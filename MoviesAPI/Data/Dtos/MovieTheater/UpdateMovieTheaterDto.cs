using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.MovieTheater
{
    public class UpdateMovieTheaterDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
    }
}
