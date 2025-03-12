using GerenciamentoCursos.Domain;
using GerenciamentoCursos.Dto;

namespace GerenciamentoCursos.Services.Interface
{
    public interface IAlunoService
    {
        Task<List<Aluno>> BuscarTodosAlunosAsync();
        Task<Aluno> BuscarAlunoPorIdAsync(int id);
        Task<RetornoPaginado<Aluno>> BuscarAlunosPaginadosAsync(int pagina, int quantidade);
        Task<bool> CriarAlunoAsync(Aluno aluno);
        Task<bool> AtualizarAlunoAsync(int id, Aluno aluno);
        Task<bool> ExcluirAlunoAsync(int id);
    }
}
