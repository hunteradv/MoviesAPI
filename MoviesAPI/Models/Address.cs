using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Address
    {
        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Logradouro é obrigatório")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string District { get; set; }
        [Required(ErrorMessage = "Número é obrigatório")]
        public int Number { get; set; }
        public MovieTheater MovieTheater { get; set; }
    }
}
