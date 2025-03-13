using Api.Domain;

namespace Api.Infra.Dto;

public class ReadAlunoDto
{
    public string? Nome { get; set; }
    public int Idade { get; set; }
    public string? Email { get; set; }
    public DateTime DataMatricula { get; set; }

    public List<ReadCursosDto> Cursos { get; set; }
}