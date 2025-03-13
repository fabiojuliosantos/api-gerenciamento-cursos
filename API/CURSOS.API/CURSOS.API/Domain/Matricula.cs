using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CURSOS.API.Domain;

public class Matricula
{
    [Key]
    [Column("MatriculaID")]
    public int MatriculaID { get; set; }

    [Required(ErrorMessage = "AlunoId é obrigatorio")]
    public int AlunoId { get; set; }
    [Required(ErrorMessage = "MatriculaId é obrigatorio")]
    public int CursoId { get; set; }
    [Required(ErrorMessage = "Data de matricula é obrigatorio.")]
    public DateTime DataMatricula { get; set; }
}
