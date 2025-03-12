using GerenciamentoCurso.Domain;

namespace GerenciamentoCurso.Services.Interface
{
    public interface IMatriculaService
    {
        Task<bool> MatricularAluno(Matricula matricula);
        Task<bool> RemoverMatricula(int id);
        Task<RetornoPaginado<Matricula>> RetornoPaginadoMatricula(int pagina, int quantidade);
    }
}
