using System.ComponentModel.DataAnnotations;

namespace gerenciamentoCursos.Dto;

public class AlunoDto
{
    [Key]
    [Required]
    public int AlunoID { get; set; }

    [Required(ErrorMessage = "O nome do aluno é obrigatorio")] //dizendo que o campo é obrigatório
    [StringLength(100, ErrorMessage = "o nome não pode ultrapassar 100 caracteres")]
    public string Nome { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A idade deve ser maior que 16 anos.")]
    public int Idade { get; set; }
    public string Email { get; set; }
    public DateTime DataMatricula { get; set; }
}
