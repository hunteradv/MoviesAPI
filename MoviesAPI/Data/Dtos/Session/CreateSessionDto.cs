using System;

namespace MoviesAPI.Data.Dtos.Session
{
    public class CreateSessionDto
    {
        public int MovieTheaterId { get; set; }
        public int MovieId { get; set; }
        public DateTime FinishTime { get; set; }
    }
}
