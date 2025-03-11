using GerenciamentoCurso.Domain;
using GerenciamentoCurso.Dto;

namespace GerenciamentoCurso.Services.Interface
{
    public interface IAlunoService
    {
        Task<IEnumerable<Alunos>> RecuperarTodosAlunos();
        Task<RetornoPaginado<Alunos>> RetornoPaginadoAluno(int pagina, int quantidade);
        Task<Alunos> BuscasrAlunosPorId(int id);
        Task<RespostaDto> CriarAluno(CriarAlunoDto criarAlunoDto);
        Task<RespostaDto> AtualizarAluno(AtualizarAlunoDto atualizarAlunoDto);
        Task<RespostaDto> DeletarAluno(int id);
    }
}
