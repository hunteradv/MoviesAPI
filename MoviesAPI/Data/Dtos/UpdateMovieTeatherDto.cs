﻿using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class UpdateMovieTeatherDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
    }
}
