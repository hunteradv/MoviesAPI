using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.Addresses
{
    public class CreateAddressDto
    {
        [Required(ErrorMessage = "Logradouro é obrigatório")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string District { get; set; }
        [Required(ErrorMessage = "Número é obrigatório")]
        public int Number { get; set; }
        public int MovieTheaterId { get; set; }
    }
}
