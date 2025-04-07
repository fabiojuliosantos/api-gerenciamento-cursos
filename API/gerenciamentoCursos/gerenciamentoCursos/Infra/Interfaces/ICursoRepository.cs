using gerenciamentoCursos.Domain;

namespace gerenciamentoCursos.Infra.Interfaces;

public interface ICursoRepository
{
    Task<bool> AdicionarCurso(Curso curso);
    Task<List<Curso>> BuscarTodosCursos();
    Task<Curso> BuscarCursoPorID(int id);
    Task<bool> AtualizarCurso(Curso curso);
    Task<bool> DeletarCurso(int id);
}
