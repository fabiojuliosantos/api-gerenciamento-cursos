using GerenciamentoCurso.Domain;

namespace GerenciamentoCurso.Services.Interface
{
    public interface IMatriculaService
    {
        Task<bool> MatricularAluno(Matricula matricula);
        Task<bool> RemoverMatricula(int id);
        Task<RetornoPaginadoAlunos<Matricula>> RetornoPaginadoMatricula(int pagina, int quantidade);
    }
}
