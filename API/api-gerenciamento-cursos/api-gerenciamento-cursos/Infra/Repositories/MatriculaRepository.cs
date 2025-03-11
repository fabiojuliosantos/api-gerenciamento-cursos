using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Infra.Interfaces;

namespace api_gerenciamento_cursos.Infra.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        public Task<bool> AdicionarMatriculaAsync(Matriculas matriculas)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AtualizarMatriculaAsync(Matriculas matriculas)
        {
            throw new NotImplementedException();
        }

        public Task<RetornoPaginado<Matriculas>> ListarMatriculasPaginadoAsync(int pagina, int qtdPorPagina)
        {
            throw new NotImplementedException();
        }
    }
}
