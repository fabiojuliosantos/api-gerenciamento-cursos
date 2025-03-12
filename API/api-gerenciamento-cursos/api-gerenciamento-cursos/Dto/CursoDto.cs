using System.ComponentModel.DataAnnotations;

namespace api_gerenciamento_cursos.Dto
{
    public class CursoDto
    {
        [Required(ErrorMessage = "O nome do curso é obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 100 letras")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a descrição do curso")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "A descrição deve conter entre 10 e 255 letras")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe a carga horária do curso")]
        public int CargaHoraria { get; set; }
    }
}
