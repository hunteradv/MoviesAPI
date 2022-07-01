using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Session
    {
        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }
        public virtual MovieTheater MovieTheater { get; set; }
        public virtual Movie Movie { get; set; }
        public int MovieId { get; set; }
        public int MovieTheaterId { get; set; }
        public DateTime FinishTime { get; set; }
    }
}
