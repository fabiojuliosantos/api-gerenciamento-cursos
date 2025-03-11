using GerenciamentoCursos.Domain;

namespace GerenciamentoCursos.Infra.Interfaces
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>> BuscarTodosAlunosAsync();
        Task<Aluno> BuscarAlunoPorIdAsync(int id);
        Task<RetornoPaginado<Aluno>> BuscarAlunosPaginadosAsync(int pagina, int quantidade);
        Task<bool> CriarAlunoAsync(Aluno aluno);
        Task<bool> AtualizarAlunoAsync(int id, Aluno aluno);
        Task<bool> ExcluirAlunoAsync(int id);
    }
}
