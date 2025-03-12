using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GerenciamentoCurso.Domain;

public class Alunos
{
    public int AlunoId { get; set; }
    [NotNull]
    [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 100 letras")]
    public string Nome { get; set; }
    [NotNull]
    [Required(ErrorMessage = "Informe a sua idade")]
    public int Idade { get; set; }
    [NotNull]
    public string Email { get; set; }
    public DateTime DataMatricula { get; set; }
    public List<Cursos> CursoMatriculado { get; set; }

}
