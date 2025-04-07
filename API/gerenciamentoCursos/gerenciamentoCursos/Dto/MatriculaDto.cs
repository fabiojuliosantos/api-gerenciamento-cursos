using System.ComponentModel.DataAnnotations;

namespace gerenciamentoCursos.Dto;

public class MatriculaDto
{
    [Key]
    [Required]
    public int MatriculaID { get; set; }

    [Required(ErrorMessage = "O identificador do aluno é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    public int AlunoID { get; set; }

    [Required(ErrorMessage = "O identificador do curso é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    public int CursoID { get; set; }
    public DateTime DataMatricula { get; set; }
}

