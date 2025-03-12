using Curso_API.Domain.Entities;
using Curso_API.Dto;

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
