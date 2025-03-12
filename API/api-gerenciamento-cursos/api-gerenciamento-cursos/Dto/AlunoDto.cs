using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace api_gerenciamento_cursos.Dto
{
    public class AlunoDto
    {
        [NotNull]
        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 100 letras")]
        public string Nome { get; set; }
        [NotNull]
        [Required(ErrorMessage = "Informe a sua idade")]
        [Range(0, 110, ErrorMessage = "A idade deve estar entre .")]
        public int Idade { get; set; }
        [NotNull]
        public string Email { get; set; }
    }
}
