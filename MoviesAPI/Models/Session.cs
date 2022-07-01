using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Session
    {
        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Cinema é obrigatório")]
        public virtual MovieTheater MovieTheater { get; set; }
        [Required(ErrorMessage = "Filme é obrigatório")]
        public virtual Movie Movie { get; set; }
        [Required(ErrorMessage = "MovieId é obrigatório")]
        public int MovieId { get; set; }
        [Required(ErrorMessage = "MovieTheaterId é obrigatório")]
        public int MovieTheaterId { get; set; }
        [Required(ErrorMessage = "Data de encerrameto é obrigatória")]
        public DateTime FinishTime { get; set; }
    }
}
