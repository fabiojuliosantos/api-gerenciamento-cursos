using CURSOS.API.Domain;

namespace CURSOS.API.Infra.Interfaces;

public interface IMatriculaRepository
{
    Task<RetornoPaginado<Matricula>> BuscarTodasMatriculasAsync(int pagina, int quantidade);
    Task<bool> AdicionarMatriculaPorAlunoAsync(Matricula matricula);
    Task<bool> CancelarMatriculaAsync(int id);
}
