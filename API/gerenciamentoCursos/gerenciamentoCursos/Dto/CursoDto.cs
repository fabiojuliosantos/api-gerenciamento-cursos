using System.ComponentModel.DataAnnotations;

namespace gerenciamentoCursos.Dto;

public class CursoDto
{
    [Key]
    [Required]
    public int CursoID { get; set; }

    [Required(ErrorMessage = "O nome do curso é obrigatorio")]
    [StringLength(50, ErrorMessage = "o nome não pode ultrapassar 50 caracteres")]
    public string Nome { get; set; }
    public string Descricao { get; set; }

    [Required(ErrorMessage = "A carga horária do curso é obrigatória")]
    [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser maior que zero.")]
    public int CargaHoraria { get; set; }
}
