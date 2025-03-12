using CURSOS.API.Domain;
using CURSOS.API.DTOs;

namespace CURSOS.API.Application.Interfaces;

public interface IAlunosServices
{
    Task<IEnumerable<Alunos>> BuscarAlunosAsync();
    Task<RetornoPaginado<Alunos>> BuscarAlunosPaginadosAsync(int pagina, int quantidade);
    Task<Alunos> BuscarAlunosPorIdAsync(int id);
    Task<bool> AdicionarAlunoAsync(AlunosDTO alunosDTO);
    Task<bool> AtualizarAlunoAsync(AlunosDTO alunosDTO);
    Task<bool> DeletarAlunosAsync(int id);
}
