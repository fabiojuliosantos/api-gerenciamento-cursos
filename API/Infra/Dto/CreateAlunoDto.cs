using System.ComponentModel.DataAnnotations;

//Considere criar os DTOs fora da Infra, já que são objetos de transferência de dados, e atuam em abstração
namespace Api.Infra.Dto;

public class CreateAlunoDto
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Idade é obrigatório")]
    public int Idade { get; set; }
    [Required(ErrorMessage = "Email é obrigatório")]
    public string? Email { get; set; }
    public DateTime DataMatricula { get; set; }
}