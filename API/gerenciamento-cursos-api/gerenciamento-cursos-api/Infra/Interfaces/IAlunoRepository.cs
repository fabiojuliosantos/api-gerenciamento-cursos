using gerenciamento_cursos_api.Domain.Entities;

namespace gerenciamento_cursos_api.Infra.Interfaces;

public interface IAlunoRepository
{
    Task<RetornoPaginado<Aluno>> BuscarAlunosPagina(int pagina, int qtdRegistros);
    Task<List<Aluno>> BuscarTodosAlunos();
    Task<Aluno> BuscarAlunoId(int id);
    Task<bool> InserirAluno(Aluno aluno);
    Task<bool> AtualizarAluno(Aluno aluno);
    Task<bool> ExcluirAluno(int id);
}
