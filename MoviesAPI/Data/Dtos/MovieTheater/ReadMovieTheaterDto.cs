﻿using MoviesAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.MovieTheater
{
    public class ReadMovieTheaterDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
        public DateTime ReadTime { get; set; }
        public Address Address { get; set; }
    }
}
