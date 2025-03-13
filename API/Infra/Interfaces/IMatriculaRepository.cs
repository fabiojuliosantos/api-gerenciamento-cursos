using Api.Domain;

namespace Api.Infra.Interfaces;

public interface IMatriculaRepository
{
    Task<bool> CriaMatricula(Matricula matricula);
    Task<List<Matricula>> ListaMatriculas();
    Task<RetornoPaginado<Matricula>> ListaMatriculaPaginada(int pagina, int quantidade);
    Task<bool> DeletaMatricula(int id);
}