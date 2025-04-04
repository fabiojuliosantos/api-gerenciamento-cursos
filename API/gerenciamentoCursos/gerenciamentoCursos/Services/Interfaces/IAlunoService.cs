
using gerenciamentoCursos.Domain;

namespace gerenciamentoCursos.Services.Interfaces;

public interface IAlunoService
{
    Task<bool> AdicionarAluno(Aluno aluno);
    Task<List<Aluno>> BuscarTodosAlunos();
    Task<Aluno> BuscarAlunoPorId(int id);
    Task<bool> AtualizarAluno(Aluno aluno);
    Task<bool> DeletarAluno(int id);
}
