using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.MovieTheaters
{
    public class CreateMovieTheaterDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int ManagerId { get; set; }
    }
}
