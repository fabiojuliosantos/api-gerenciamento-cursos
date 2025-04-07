using System.Reflection.Metadata.Ecma335;
using gerenciamentoCursos.Domain;
using gerenciamentoCursos.Infra.Interfaces;
using gerenciamentoCursos.Services.Interfaces;

namespace gerenciamentoCursos.Services.Services;

public class MatriculaService : IMatriculaService
{
    private readonly IMatriculaRepository _repository;

    public MatriculaService(IMatriculaRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AdicionarMatricula(Matricula matricula)
    {
        try
        {
            return await _repository.AdicionarMatricula(matricula);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Matricula>> BuscarTodasMatriculas()
    {
        try
        {
            return await _repository.BuscarTodasMatriculas();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Matricula> BuscarMatriculaPorID(int id)
    {
        try
        {
            return await _repository.BuscarMatriculaPorID(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> AtualizarMatricula(Matricula matricula)
    {
        try
        {
            return await _repository.AtualizarMatricula(matricula);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> DeletarMatricula(int id)
    {
        try
        {
            return await _repository.DeletarMatricula(id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
