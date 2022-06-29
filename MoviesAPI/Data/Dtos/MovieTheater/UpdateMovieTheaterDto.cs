using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.MovieTheaters
{
    public class UpdateMovieTheaterDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
    }
}
