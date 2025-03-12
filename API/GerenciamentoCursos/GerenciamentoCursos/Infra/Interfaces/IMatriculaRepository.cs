using GerenciamentoCursos.Domain;

namespace GerenciamentoCursos.Infra.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<RetornoPaginado<Matricula>> BuscarMatriculasPaginadasAsync(int pagina, int quantidade);
        Task<bool> CriarMatriculaAsync(Matricula matricula);
        Task<bool> ExcluirMatriculaAsync(int id);
    }
}
