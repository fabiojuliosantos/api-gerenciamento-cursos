using api.gerenciamento.cursos.Domain;

public interface IAlunoService
{
    Task<RetornoPaginadoAluno<Aluno>> BuscarAlunosPorPaginaAsync(int pagina, int quantidade);
    Task<Aluno> BuscarAlunoPorId(int id);
    Task<List<Aluno>> BuscarTodosAlunos();
    Task<bool> InserirAluno(Aluno aluno);
    Task<bool> AtualizarAluno(Aluno aluno);
    Task<bool> ExcluirAluno(int id);
}