using System;

namespace MoviesAPI.Data.Dtos.Manager
{
    public class ReadManagerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReadTime { get; set; }
    }
}
