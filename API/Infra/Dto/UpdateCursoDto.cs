using System.ComponentModel.DataAnnotations;

namespace Api.Infra.Dto;

public class UpdateCursoDto
{
    [Required]
    public int CursoId { get; set; }
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Descrição é obrigatório")]
    public string? Descricao { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser positivo e maior ou igaul a 1.")]
    public int CargaHoraria { get; set; }
}
  