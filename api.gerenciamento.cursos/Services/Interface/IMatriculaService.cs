using api.gerenciamento.cursos.Domain;

namespace api.gerenciamento.cursos.Services.Interface
{
    public interface IMatriculaService
    {
        Task<RetornoPaginadoMatricula<Matricula>> BuscarMatriculaPorPaginaAsync(int pagina, int quantidade); // Adicione esta linha
        Task<Matricula> BuscarMatriculaPorId(int id);
        Task<List<Matricula>> BuscarTodasMatriculas();
        Task<bool> InserirMatricula(Matricula matricula);
        //Task<bool> AtualizarMatricula(Matricula matricula);
        Task<bool> ExcluirMatricula(int id);
    }
}
