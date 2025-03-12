using api.gerenciamento.cursos.Domain;

namespace api.gerenciamento.cursos.Infra.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<RetornoPaginadoMatricula<Matricula>> BuscarMatriculaPorPaginaAsync(int pagina, int quantidade);
        Task<Matricula> BuscarMatriculaPorId(int id);
        Task<List<Matricula>> BuscarTodasMatriculas();
        Task<bool> InserirMatricula(Matricula matricula);
        //Task<bool> AtualizarMatricula(Matricula matricula);
        Task<bool> ExcluirMatricula(int id);
    }
}
