using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class MovieTheater
    {
        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Endereço é obrigatório")]
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Gerente é obrigatório")]
        public virtual Manager Manager { get; set; }
        public int ManagerId { get; set; }
        [JsonIgnore]
        public virtual List<Session> Sessions { get; set; }
    }
}
