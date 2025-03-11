using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Infra.Interfaces;

namespace api_gerenciamento_cursos.Infra.Repositories
{
    public class CursosRepository : ICursosRepository
    {
        public Task<bool> AdicionaCursosAsync(Cursos cursos)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AtualizarCursosAsync(Cursos cursos)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletaCursosAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cursos>> RecuperaCursosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cursos> RecuperaCursosPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
