using CURSOS.API.Application.Interfaces;
using CURSOS.API.Domain;
using CURSOS.API.DTOs;
using CURSOS.API.Infra.Interfaces;

namespace CURSOS.API.Application.Services;

public class MatriculaServices : IMatriculaServices
{
    private readonly IMatriculaRepository _repository;

    public MatriculaServices(IMatriculaRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AdicionarMatriculaPorAlunoAsync(MatriculasDTO matriculaDTO)
    {
        try
        {
            var matricula = new Matricula
            {
                AlunoId = matriculaDTO.AlunoId,
                CursoId = matriculaDTO.CursoId,
                DataMatricula = matriculaDTO.DataMatricula
            };
            return await _repository.AdicionarMatriculaPorAlunoAsync(matricula);
        }
        catch (Exception)
        {
            throw;
        };
    }

    public async Task<RetornoPaginado<Matricula>> BuscarTodasMatriculasAsync(int pagina, int quantidade)
    {
        try
        {
            var matriculas = await _repository.BuscarTodasMatriculasAsync(pagina, quantidade);
            return matriculas;
        }
        catch(Exception)
        {
            throw;
        }
    }

    public async Task<bool> CancelarMatriculaAsync(int id)
    {
        try
        {
            return await _repository.CancelarMatriculaAsync(id);
        }
        catch(Exception)
        {
            throw;
        };
    }
}
