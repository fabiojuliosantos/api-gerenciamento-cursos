using CURSOS.API.Domain;

namespace CURSOS.API.Infra.Interfaces;

public interface IAlunosRepository
{
    Task<IEnumerable<Alunos>> BuscarAlunosAsync();
    Task<RetornoPaginado<Alunos>> BuscarAlunosPaginadosAsync(int pagina, int quantidade);
    Task<Alunos> BuscarAlunosPorIdAsync(int id);
    Task<bool> AdicionarAlunoAsync(Alunos alunos);
    Task<bool> AtualizarAlunoAsync(Alunos alunos);
    Task<bool> DeletarAlunosAsync(int id);
}
