using GerenciamentoCurso.Domain;

namespace GerenciamentoCurso.Infra.Interface
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Alunos>> RecuperarTodosAlunos();
        Task<RetornoPaginado<Alunos>> RetornoPaginadoAluno(int pagina, int quantidade);
        Task<Alunos> BuscasrAlunosPorId(int id);
        Task<bool> CriarAluno(Alunos alunos);
        Task<bool> AtualizarAluno(Alunos alunos);
        Task<bool> DeletarAluno(int id);
    }
}
