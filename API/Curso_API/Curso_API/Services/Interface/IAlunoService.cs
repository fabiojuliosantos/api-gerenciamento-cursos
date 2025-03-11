using Curso_API.Domain;

namespace Curso_API.Services.Interface;

public interface IAlunoService
{
    Task<RetornoPaginado<Aluno>> BuscarAlunoPorPaginaAsync(int pagina, int quantidade);
    Task<List<Aluno>> BuscarTodosAlunosAsync();
    Task<Aluno> BuscarAlunoPorIdAsync(int alunoID);
    Task<bool> AdicionarAlunoAsync(Aluno aluno);
    Task<bool> AtualizarAlunoAsync(Aluno aluno);
    Task<bool> ExcluirAlunoAsync(int alunoID);
}
