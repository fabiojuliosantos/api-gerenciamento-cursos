using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Dto;

namespace api_gerenciamento_cursos.Services.Interface
{
    public interface IMatriculaService
    {
        Task<RetornoPaginado<Matriculas>> ListarMatriculasPaginadoAsync(int pagina, int qtdPorPagina);
        Task<bool> AdicionarMatriculaAsync(MatriculaDto matriculas);
        Task<bool> AtualizarMatriculaAsync(MatriculaDto matriculas);
    }
}
