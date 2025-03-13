using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GerenciamentoCurso.Dto;

public class AlunoDto
{
    [NotNull]
    [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 50 caracteres")]
    public string Nome { get; set; }
    [NotNull]
    [Required(ErrorMessage = "Informe a sua idade")]
    [Range(5, 110, ErrorMessage = "A idade deve estar entre 5 e 110 anos")]
    public int Idade { get; set; }
    [NotNull]
    [StringLength(50,MinimumLength = 10, ErrorMessage = "Quantidade de caracteres insuficiente")]
    public string Email
    {
        get; set;

    }
}    

