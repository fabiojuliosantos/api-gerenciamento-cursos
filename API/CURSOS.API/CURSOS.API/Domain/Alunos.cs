using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CURSOS.API.Domain;

public class Alunos
{
    [Key]
    [Column("AlunoID")]
    public int AlunoId { get; set; }

    [Required(ErrorMessage = "Nome é obrigatorio")]
    [StringLength(100, ErrorMessage = "Nome não pode ter mais de 100 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Idade é obrigatoria")]
    [Range(1, 150, ErrorMessage = "Idade deve ser entre 1 e 150 anos")]
    public int Idade { get; set; }

    [Required(ErrorMessage = "email é obrigatorio")]
    [EmailAddress(ErrorMessage = "Email invalido.")]
    public string Email { get; set; }
    public DateTime DataMatricula { get; set; }
    public ICollection<Cursos> Cursos { get; set; } = new List<Cursos>();
}