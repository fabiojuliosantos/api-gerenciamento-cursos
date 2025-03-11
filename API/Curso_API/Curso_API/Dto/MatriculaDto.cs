using System.ComponentModel.DataAnnotations;

namespace Curso_API.Dto;

public class MatriculaDto
{
    [Required(ErrorMessage ="O id do aluno é um campo obrigatório")]
    [Range(1,int.MaxValue,ErrorMessage ="Id do aluno inválido!")]
    public int AlunoID { get; set; }
    [Required(ErrorMessage = "O id do curso é um campo obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "Id do curso inválido!")]
    public int CursoID { get; set; }
}
