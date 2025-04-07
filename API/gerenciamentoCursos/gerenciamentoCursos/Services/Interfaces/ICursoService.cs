using gerenciamentoCursos.Domain;

namespace gerenciamentoCursos.Services.Interfaces;

public interface ICursoService
{
    Task<bool> AdicionarCurso(Curso curso);
    Task<List<Curso>> BuscarTodosCursos();
    Task<Curso> BuscarCursoPorID(int id);
    Task<bool> AtualizarCurso(Curso curso);
    Task<bool> DeletarCurso(int id);
}
