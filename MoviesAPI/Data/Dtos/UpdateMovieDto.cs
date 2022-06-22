using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos
{
    public class UpdateMovieDto
    {
        public string Title { get; set; }
        [Required(ErrorMessage = "Diretor é obrigatório")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "Gênero não pode ultrapassar 30 caracteres")]
        public string Genre { get; set; }
        [Range(1, 600, ErrorMessage = "Duração deve ser no máximo 600 minutos")]
        public int Duraction { get; set; }
    }
}
