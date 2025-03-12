using CURSOS.API.Domain;
using CURSOS.API.DTOs;

namespace CURSOS.API.Application.Interfaces;

public interface IMatriculaServices
{
    Task<RetornoPaginado<Matricula>> BuscarTodasMatriculasAsync(int pagina, int quantidade);
    Task<bool> AdicionarMatriculaPorAlunoAsync(MatriculasDTO matriculaDTO);
    Task<bool> CancelarMatriculaAsync(int id);
}
