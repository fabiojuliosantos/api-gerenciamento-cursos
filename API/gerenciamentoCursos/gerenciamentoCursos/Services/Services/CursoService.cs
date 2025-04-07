using gerenciamentoCursos.Domain;
using gerenciamentoCursos.Infra.Interfaces;
using gerenciamentoCursos.Services.Interfaces;

namespace gerenciamentoCursos.Services.Services;

public class CursoService : ICursoService
{
    private readonly ICursoRepository _repository;
    public CursoService(ICursoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AdicionarCurso(Curso curso)
    {
        try
        {
            return await _repository.AdicionarCurso(curso);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Curso>> BuscarTodosCursos()
    {
        try
        {
            return await _repository.BuscarTodosCursos();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Curso> BuscarCursoPorID(int id)
    {
        try
        {
            return await _repository.BuscarCursoPorID(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> AtualizarCurso(Curso curso)
    {
        try
        {
            return await _repository.AtualizarCurso(curso);
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task<bool> DeletarCurso(int id)
    {
        try
        {
            return await _repository.DeletarCurso(id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
