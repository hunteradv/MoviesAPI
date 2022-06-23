using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class CreateMovieTeatherDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
    }
}
