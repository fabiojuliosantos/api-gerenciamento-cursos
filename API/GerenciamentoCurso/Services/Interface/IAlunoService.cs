using FluentValidation;
using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Dto;

namespace GerenciamentoCurso.Services.Interface
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoComCurso>> RecuperaTodosAlunosAsync();
        Task<RetornoPaginado<Alunos>> BuscarAlunoPorPaginaAsync(int pagina, int quantidade);
        Task<AlunoComCurso> BuscaAlunoPorIdAsync(int id);
        Task<bool> AdicionaAlunoAsync(Alunos aluno);
        Task<bool> AtualizarAlunoAsync(Alunos aluno);
        Task<bool> DeletarAlunoAsync(int id);
    }
}
