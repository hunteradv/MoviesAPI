﻿using MoviesAPI.Models;
using System;
using System.Collections.Generic;

namespace MoviesAPI.Data.Dtos.Managers
{
    public class ReadManagerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Object MovieTheaters { get; set; }
    }
}
