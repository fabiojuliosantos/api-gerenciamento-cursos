using System.ComponentModel.DataAnnotations;
using CURSOS.API.Domain;

namespace CURSOS.API.DTOs;

public class MatriculasDTO
{
    public int AlunoId { get; set; }
    [Required(ErrorMessage = "CursoId é obrigatorio")]
    public int CursoId { get; set; }
    [Required(ErrorMessage = "Data da matricula é obrigatorio.")]
    public DateTime DataMatricula { get; set; }
}
