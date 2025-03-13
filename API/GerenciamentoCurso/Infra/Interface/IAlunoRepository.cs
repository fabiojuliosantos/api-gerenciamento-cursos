using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Dto;

namespace GerenciamentoCurso.Infra.Interface
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<AlunoComCurso>> RecuperaTodosAlunosAsync();
        Task<RetornoPaginadoAlunos<Alunos>> BuscaAlunoPorPagina(int pagina, int quantidade);
        Task<AlunoComCurso> BuscaAlunoPorIdAsync(int id);
        Task<bool> AdicionaAlunoAsync(Alunos aluno);
        Task<bool> AtualizarAlunoAsync(Alunos aluno);
        Task<bool> DeletarAlunoAsync(int id);
        Task<bool> BuscarAlunoPorEmailAsync(string email);
    }
}
