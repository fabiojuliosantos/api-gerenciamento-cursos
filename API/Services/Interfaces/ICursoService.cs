using Api.Domain;
using Api.Infra.Dto;

namespace Api.Service.Interfaces;

public interface ICursoService
{
    Task<List<Curso>> ListaCursos();
    Task<Curso> ListaCursoPorId(int id);
    Task<bool> CriaCurso(CreateCursoDto cursoDto);
    Task<bool> AtualizaCurso(UpdateCursoDto cursoDto);
    Task<bool> DeletaCurso(int id);
}