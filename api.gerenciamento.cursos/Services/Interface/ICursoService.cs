using api.gerenciamento.cursos.Domain;
namespace api.gerenciamento.cursos.Service.Interface
{
    public interface ICursoService
    {
        Task<RetornoPaginadoCurso<Curso>> BuscarCursosPorPaginaAsync(int pagina, int quantidade);
        Task<Curso> BuscarCursoPorId(int id);
        Task<List<Curso>> BuscarTodosCursosAsync();
        Task<bool> ExcluirCurso(int id);
        Task<bool> AtualizarCurso(Curso curso);
        Task<bool> InserirCurso(Curso curso);
    }
}
