using Curso_API.Domain.Entities;

namespace Curso_API.Infra.Interface;

public interface ICursoRepository
{
    Task<List<Curso>> BuscarTodosCursos();
    Task<Curso> BuscarCursoPorId(int cursoID);
    Task<bool> AdicionarCurso(Curso curso);
    Task<bool> AtualizarCurso(Curso curso);
    Task<bool> ExcluirCurso(int cursoID);
}
