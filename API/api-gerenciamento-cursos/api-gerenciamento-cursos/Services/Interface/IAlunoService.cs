using api_gerenciamento_cursos.Domain;
using api_gerenciamento_cursos.Dto;

namespace api_gerenciamento_cursos.Services.Interface
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> RecuperaTodosAlunosAsync();
        Task<RetornoPaginado<Aluno>> BuscarAlunoPorPaginaAsync(int pagina, int quantidade);
        Task<Aluno> BuscaAlunoPorIdAsync(int id);
        Task<bool> AdicionaAlunoAsync(Aluno aluno);
        Task<bool> AtualizarAlunoAsync(Aluno aluno);
        Task<bool> DeletarAlunoAsync(int id);
    }
}
