using System.ComponentModel.DataAnnotations;

namespace CURSOS.API.DTOs;

public class AlunosDTO
{
    [Required(ErrorMessage = "Nome é obrigatorio.")]
    [StringLength(100, ErrorMessage = "Nome não pode ter mais de 100 caracteres")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Idade é obrigatoria.")]
    [Range(1, 150, ErrorMessage = "Idade deve ser entre 1 e 150 anos")]
    public int Idade { get; set; }
    [Required(ErrorMessage = "Idade é obrigatoria")]
    [EmailAddress(ErrorMessage = "Email invalido.")]
    public string Email { get; set; }
    public DateTime DataMatricula { get; set; }
}
