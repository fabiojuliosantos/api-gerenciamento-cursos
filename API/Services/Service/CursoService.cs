using Api.Domain;
using Api.Infra.Dto;
using Api.Infra.Interfaces;
using Api.Service.Interfaces;
using Api.Utils;
using AutoMapper;

namespace Api.Service.Service;

public class CursoService : ICursoService
{
    private readonly ICursoRepository _repository;
    private readonly IMapper _mapper;

    public CursoService(IMapper mapper, ICursoRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Curso> ListaCursoPorId(int id)
    {
        try
        {
            Curso curso = await _repository.ListaCursoPorId(id);
            
            if (curso is null)
                throw new CustomerException("Curso não foi encontrado", 404);
    
            return curso;
        }
        catch (Exception) { throw; }
    }

    public async Task<List<Curso>> ListaCursos()
    {
        try
        {
            return await _repository.ListaTodosCursos();
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> CriaCurso(CreateCursoDto cursoDto)
    {
        try
        {
            Curso curso = _mapper.Map<Curso>(cursoDto);
            return await _repository.CriaCurso(curso);
    
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> AtualizaCurso(UpdateCursoDto cursoDto)
    {
        try
        {
            Curso curso = _mapper.Map<Curso>(cursoDto);
            return await _repository.AtualizaCurso(curso);
        }
        catch (Exception) { throw; }

    }

    public async Task<bool> DeletaCurso(int id)
    {
        try
        {
            return await _repository.DeletaAluno(id);
        }
        catch (Exception) { throw; }
    }
}