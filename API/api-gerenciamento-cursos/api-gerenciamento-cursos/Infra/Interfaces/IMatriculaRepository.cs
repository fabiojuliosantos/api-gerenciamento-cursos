using api_gerenciamento_cursos.Domain;

namespace api_gerenciamento_cursos.Infra.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<RetornoPaginado<Matriculas>> ListarMatriculasPaginadoAsync(int pagina, int qtdPorPagina);
        Task<bool> AdicionarMatriculaAsync (Matriculas matriculas);
        Task<bool> DeletarMatriculaAsync(int id);
    }
}
