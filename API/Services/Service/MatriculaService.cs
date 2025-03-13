using Api.Domain;
using Api.Infra.Dto;
using Api.Infra.Interfaces;
using Api.Service.Interfaces;
using AutoMapper;

namespace Api.Service.Service;

public class MatriculaService : IMatriculaService
{
    private readonly IMatriculaRepository _repository;
    private readonly IMapper _mapper;

    public MatriculaService(IMatriculaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> CriaMatricula(CreateMatricula matriculadto)
    {
        try
        {
            Matricula matricula = _mapper.Map<Matricula>(matriculadto);
            return await _repository.CriaMatricula(matricula);
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> DeletaMatricula(int id)
    {
        try
        {
            return await _repository.DeletaMatricula(id);
        }
        catch (Exception) { throw; }
    }

    public Task<RetornoPaginado<Matricula>> ListaMatriculaRetornoPaginado(int pagina, int quantidade)
    {
        try
        {
            return _repository.ListaMatriculaPaginada(pagina, quantidade);
        }
        catch (Exception) { throw; }
    }

    public async Task<List<Matricula>> ListaMatriculas()
    {
        try
        {
            return await _repository.ListaMatriculas();
        }
        catch (Exception) { throw; }
    }
}