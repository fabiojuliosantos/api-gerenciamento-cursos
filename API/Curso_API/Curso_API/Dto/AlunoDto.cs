using System.ComponentModel.DataAnnotations;

namespace Curso_API.Dto;

public class AlunoDto
{
    [Required(ErrorMessage ="O nome do aluno é um campo obrigatório!")]
    [MaxLength(100, ErrorMessage = "O nome do aluno não pode possuir mais de 100 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A idade do aluno é um campo obrigatório!")]
    [Range(1,int.MaxValue,ErrorMessage ="Idade inválida.")]
    public int Idade { get; set; }
    [Required(ErrorMessage = "O E-mail do aluno é um campo obrigatório!")]
    [MaxLength(50,ErrorMessage ="O E-mail não pode possuir mais de 50 caracteres.")]
    public string Email { get; set; }
}
