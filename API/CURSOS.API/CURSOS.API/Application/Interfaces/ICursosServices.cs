using CURSOS.API.Domain;
using CURSOS.API.DTOs;
using CURSOS.API.Infra.Interfaces;

namespace CURSOS.API.Application.Interfaces;

public interface ICursosServices
{
    Task<IEnumerable<Cursos>> BuscarCursoAsync();
    Task<Cursos> BuscarCursoPorIdAsync(int id);
    Task<bool> AdicionarCursoAsync(CursosDTO cursosDTO);
    Task<bool> AtualizarCursoAsync(CursosDTO cursosDTO);
    Task<bool> DeletarCursoAsync(int id);

}
