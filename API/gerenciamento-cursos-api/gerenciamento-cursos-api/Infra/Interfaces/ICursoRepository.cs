using gerenciamento_cursos_api.Domain.Entities;

namespace gerenciamento_cursos_api.Infra.Interfaces;

public interface ICursoRepository
{
    Task<RetornoPaginado<Curso>> BuscarCursosPagina(int pagina, int qtdRegistros);
    Task<List<Curso>> BuscarTodosCursos();
    Task<Curso> BuscarCursoId(int id);
    Task<bool> InserirCurso(Curso curso);
    Task<bool> AtualizarCurso(Curso curso);
    Task<bool> RemoverCurso(int id);
}
