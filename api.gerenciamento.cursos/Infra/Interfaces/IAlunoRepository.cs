using api.gerenciamento.cursos.Domain;

namespace api.gerenciamento.cursos.Infra.Interfaces
{
    public interface IAlunoRepository
    {
        Task<RetornoPaginadoAluno<Aluno>> BuscarAlunosPorPagina(int pagina, int quantidade);
        Task<List<Aluno>> BuscarTodosAlunos();
        Task<Aluno> BuscarAlunoPorId(int id);
        Task<bool> InserirAluno(Aluno aluno);
        Task<bool> AtualizarAluno(Aluno aluno);
        Task<bool> ExcluirAluno(int id);

    }
}
