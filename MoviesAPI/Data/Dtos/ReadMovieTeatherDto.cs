using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class ReadMovieTeatherDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
        public DateTime ReadTime { get; set; }
    }
}
