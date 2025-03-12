using CURSOS.API.Application.Interfaces;
using CURSOS.API.Domain;
using CURSOS.API.DTOs;
using CURSOS.API.Infra.Interfaces;

namespace CURSOS.API.Application.Services;

public class CursosServices : ICursosServices
{
    private readonly ICursosRepository _repository;

    public CursosServices(ICursosRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AdicionarCursoAsync(CursosDTO cursosDTO)
    {
        try
        {
            var curso = new Cursos
            {
                Nome = cursosDTO.Nome,
                Descricao = cursosDTO.Descricao,
                CargaHoraria = cursosDTO.CargaHoraria
            };
            return await _repository.AdicionarCursoAsync(curso);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> AtualizarCursoAsync(CursosDTO cursosDTO)
    {
        try
        {
            var curso = new Cursos
            {
                CursoId = cursosDTO.CursoId,
                Nome = cursosDTO.Nome,
                Descricao = cursosDTO.Descricao,
                CargaHoraria = cursosDTO.CargaHoraria
            };
            return await _repository.AtualizarCursoAsync(curso);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Cursos>> BuscarCursoAsync()
    {
        try
        {
            return await _repository.BuscarTodosCursosAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Cursos> BuscarCursoPorIdAsync(int id)
    {
        try
        {
            return await _repository.BuscarCursoPorIdAsync(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeletarCursoAsync(int id)
    {
        try
        {
            return await _repository.DeletarCursoAsync(id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
