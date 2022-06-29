using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Manager
    {
        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
        public virtual List<MovieTheater> MovieTheaters { get; set; }
    }
}
