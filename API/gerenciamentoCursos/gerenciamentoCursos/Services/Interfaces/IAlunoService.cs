using gerenciamentoCursos.Domain;

namespace gerenciamentoCursos.Services.Interfaces;

public interface IAlunoService
{
    Task<List<Aluno>> BuscarTodosAlunos();
}
