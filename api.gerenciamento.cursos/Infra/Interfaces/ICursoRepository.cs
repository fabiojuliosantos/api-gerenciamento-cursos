using api.gerenciamento.cursos.Domain;

namespace api.gerenciamento.cursos.Infra.Interfaces
{
    public interface ICursoRepository
    {
        Task<RetornoPaginadoCurso<Curso>> BuscarCursosPorPaginaAsync(int pagina, int quantidade);
        Task<List<Curso>> BuscarTodosCursos();
        Task<Curso> BuscarCursoPorId(int id);
        Task<bool> InserirCurso(Curso curso);
        Task<bool> AtualizarCurso(Curso curso);
        Task<bool> ExcluirCurso(int id);

    }
}
