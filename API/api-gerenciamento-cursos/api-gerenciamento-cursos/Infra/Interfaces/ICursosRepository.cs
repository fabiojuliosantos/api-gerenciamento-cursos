using api_gerenciamento_cursos.Domain;

namespace api_gerenciamento_cursos.Infra.Interfaces
{
    public interface ICursosRepository
    {
        Task<IEnumerable<Cursos>> RecuperaCursosAsync();
        Task<Cursos> RecuperaCursosPorIdAsync(int id);
        Task<bool> AdicionaCursosAsync(Cursos cursos);
        Task<bool> AtualizarCursosAsync(Cursos cursos);
        Task<bool> DeletaCursosAsync(int id);
    }
}
