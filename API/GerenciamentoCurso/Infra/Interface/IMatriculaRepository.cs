using GerenciamentoCurso.Domain;

namespace GerenciamentoCurso.Infra.Interface
{
    public interface IMatriculaRepository
    {
        Task<bool> MatricularAluno(Matricula matricula);
        Task<bool> RemoverMatricula(int id);
        Task<RetornoPaginado<Matricula>> RetornoPaginadoMatricula(int pagina, int quantidade);

    }
}
