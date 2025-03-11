using Curso_API.Domain;

namespace Curso_API.Infra.Interface;

public interface IAlunoRepository
{
    Task<RetornoPaginado<Aluno>> BuscarAlunoPorPagina(int pagina, int quantidade);
    Task<List<Aluno>> BuscarTodosAlunos();
    Task<Aluno> BuscarAlunoPorId(int alunoID);
    Task<bool> AdicionarAluno(Aluno aluno);
    Task<bool> AtualizarAluno(Aluno aluno);
    Task<bool> ExcluirAluno(int alunoID);
}
