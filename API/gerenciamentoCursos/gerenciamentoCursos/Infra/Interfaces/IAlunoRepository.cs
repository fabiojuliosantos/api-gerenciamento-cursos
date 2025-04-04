using gerenciamentoCursos.Domain;

namespace gerenciamentoCursos.Infra.Interfaces;

public interface IAlunoRepository
{
    Task<bool> AdicionarAluno(Aluno aluno);
    Task<List<Aluno>> BuscarTodosAlunos();
    Task<Aluno> BuscarAlunoPorId(int id);
    Task<bool> AtualizarAluno(Aluno aluno);
    Task<bool> DeletarAluno(int id);
}
