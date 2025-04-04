using gerenciamentoCursos.Domain;

namespace gerenciamentoCursos.Infra.Interfaces;

public interface IAlunoRepository
{
    Task<List<Aluno>> BuscarTodosAlunos();
}
