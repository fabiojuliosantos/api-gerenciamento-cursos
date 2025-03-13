using System.ComponentModel.DataAnnotations;

namespace Api.Infra.Dto;

public class CreateMatricula
{
    [Required]
    public int AlunoId { get; set; }
    [Required]
    public int CursoId { get; set; }
    public DateTime DataMatricula { get; set; }
}