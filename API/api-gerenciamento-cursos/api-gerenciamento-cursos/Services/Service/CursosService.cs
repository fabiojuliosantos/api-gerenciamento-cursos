using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Services.Interface;

namespace api_gerenciamento_cursos.Services.Service
{
    public class CursosService : ICursosService
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
