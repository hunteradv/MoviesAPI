using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class MovieTheater
    {
        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
    }
}
