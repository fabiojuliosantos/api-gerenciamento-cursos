using System.ComponentModel.DataAnnotations;

namespace Api.Infra.Dto;

public class UpdateAlunoDto
{
    [Required]
    public int AlunoID { get; set; }
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Idade é obrigatório")]
    public int Idade { get; set; }
    [Required(ErrorMessage = "Email é obrigatório")]
    public string? Email { get; set; }
    public DateTime DataMatricula { get; set; }
}