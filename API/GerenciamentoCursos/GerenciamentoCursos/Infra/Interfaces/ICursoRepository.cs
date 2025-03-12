using GerenciamentoCursos.Domain;

namespace GerenciamentoCursos.Infra.Interfaces
{
    public interface ICursoRepository
    {
        Task<List<Curso>> BuscarTodosCursosAsync();
        Task<Curso> BuscarCursoPorIdAsync(int id);
        Task<bool> CriarCursoAsync(Curso curso);
        Task<bool> AtualizarCursoAsync(int id, Curso curso);
        Task<bool> ExcluirCursoAsync(int id);
    }
}
