using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Dto;

namespace api_gerenciamento_cursos.Services.Interface
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> RecuperaTodosAlunosAsync();
        Task<RetornoPaginado<Aluno>> BuscarAlunoPorPaginaAsync(int pagina, int quantidade);
        Task<Aluno> BuscaAlunoPorIdAsync(int id);
        Task<bool> AdicionaAlunoAsync(AlunoDto aluno);
        Task<bool> AtualizarAlunoAsync(AlunoDto aluno);
        Task<bool> DeletarAlunoAsync(int id);
    }
}
