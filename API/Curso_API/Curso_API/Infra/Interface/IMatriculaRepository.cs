using Curso_API.Domain.Entities;

namespace Curso_API.Infra.Interface;

public interface IMatriculaRepository
{
    Task<bool> AdicionarMatricula(Matricula matricula);
    Task<RetornoPaginado<Matricula>> BuscarMatriculaPaginada(int pagina, int quantidade);
    Task<bool> ExcluirMatricula(int matriculaID);
}
