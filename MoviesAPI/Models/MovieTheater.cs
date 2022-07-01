using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class MovieTheater
    {
        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
        public virtual Manager Manager { get; set; }
        public int ManagerId { get; set; }
        public virtual List<Session> Sessions { get; set; }
    }
}
