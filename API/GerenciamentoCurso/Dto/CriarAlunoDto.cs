using GerenciamentoCurso.Domain;

namespace GerenciamentoCurso.Dto;

public class CriarAlunoDto
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
    public DateTime DataMatricula { get; set; }

}
