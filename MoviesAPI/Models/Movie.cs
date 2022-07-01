using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class Movie
    {
        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Título é obrigatório")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Diretor é obrigatório")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "Gênero não pode ultrapassar 30 caracteres")]
        public string Genre { get; set; }
        [Range(1, 600, ErrorMessage = "Duração deve ser no máximo 600 minutos")]
        public int Duraction { get; set; }
        [JsonIgnore]
        public virtual List<Session> Sessions { get; set; }
    }
}
