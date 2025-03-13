using Api.Domain;
using Api.Infra.Dto;

namespace Api.Service.Interfaces;

public interface IMatriculaService
{
    Task<bool> CriaMatricula(CreateMatricula matriculadto);
    Task<List<Matricula>> ListaMatriculas();

    Task<RetornoPaginado<Matricula>> ListaMatriculaRetornoPaginado(int pagina, int quantidade);
    Task<bool> DeletaMatricula(int id);
}