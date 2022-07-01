using MoviesAPI.Models;
using System;

namespace MoviesAPI.Data.Dtos.Session
{
    public class ReadSessionDto
    {
        public int Id { get; set; }
        public MovieTheater MovieTheater { get; set; }
        public Movie Movie { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime ReadTime { get; set; }
    }
}
