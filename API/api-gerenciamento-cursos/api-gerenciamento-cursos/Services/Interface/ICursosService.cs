using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Dto;

namespace api_gerenciamento_cursos.Services.Interface
{
    public interface ICursosService
    {
        Task<IEnumerable<Cursos>> RecuperaCursosAsync();
        Task<Cursos> RecuperaCursosPorIdAsync(int id);
        Task<bool> AdicionaCursosAsync(Cursos cursos);
        Task<bool> AtualizarCursosAsync(Cursos cursos);
        Task<bool> DeletaCursosAsync(int id);
    }
}
