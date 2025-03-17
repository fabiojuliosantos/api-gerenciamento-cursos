using System.ComponentModel.DataAnnotations;

namespace CURSOS.API.DTOs;

public class CursosDTO
{
    public int CursoId { get; set; }
    [Required(ErrorMessage = "Nome é obrigatorio")]
    [StringLength(100, ErrorMessage = "Nome nao pode ter mais de 100 caracteres.")]
    public string? Nome { get; set; }

    [StringLength(500, ErrorMessage = "Descricao nao pode ter mais de 500 caracteres.")]
    public string? Descricao { get; set; }
    [Required(ErrorMessage = "Carga horaria é obrigatorio")]
    public int CargaHoraria { get; set; }
}
