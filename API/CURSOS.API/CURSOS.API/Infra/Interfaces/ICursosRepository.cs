using CURSOS.API.Domain;

namespace CURSOS.API.Infra.Interfaces;

public interface ICursosRepository
{
    Task<IEnumerable<Cursos>> BuscarTodosCursosAsync();
    Task<Cursos> BuscarCursoPorIdAsync(int id);
    Task<bool> AdicionarCursoAsync(Cursos cursos);
    Task<bool> AtualizarCursoAsync(Cursos cursos);
    Task<bool> DeletarCursoAsync(int id);
}
